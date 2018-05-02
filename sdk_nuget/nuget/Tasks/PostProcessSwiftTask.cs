using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using Xamarin.MacDev.Tasks;

namespace Sdk.Project.Prototype.Tasks
{
	public class PostProcessSwiftTask : Task
	{
		[Required]
		public string OutputDirectory { get; set; }

		[Required]
		public string ToolPath { get; set; }
		
		static void CreateDirectoryAsNeeded (string path)
		{
			if (!Directory.Exists (path))
				Directory.CreateDirectory (path);
		}

		static void MoveAndReplace (string file, string finalLocation)
		{
			if (File.Exists (finalLocation))
			        File.Delete (finalLocation);
			File.Move (file, finalLocation);
		}


		// XamWrapping comes out as a raw dylib but other
		// parts of SoM expect it to be a framework, so let's play pretend
		string CreateXamWrappingFramework (string libraryName)
		{
			string originalLibrary = Path.Combine (OutputDirectory, libraryName);
			if (!File.Exists (originalLibrary))
				throw new InvalidOperationException ($"{libraryName} not found in expected location ({originalLibrary}).");

			Log.LogMessage (MessageImportance.Normal, $"Processing {originalLibrary}");  

			string frameworkPath = Path.Combine (OutputDirectory, libraryName + ".framework");
			CreateDirectoryAsNeeded (frameworkPath);

			string finalLibraryPath = Path.Combine (frameworkPath, libraryName);
			MoveAndReplace (originalLibrary, finalLibraryPath);
			return finalLibraryPath;
		}

		static ProcessStartInfo GetProcessStartInfo (string tool, string args)
		{
			var startInfo = new ProcessStartInfo (tool, args);
			startInfo.WorkingDirectory = Environment.CurrentDirectory;
			startInfo.CreateNoWindow = true;
			return startInfo;
		}

		int Run (string program, string args)
		{
			using (var stderr = new StringWriter ()) {
				using (var process = ProcessUtils.StartProcess (GetProcessStartInfo (program, args), null, null)) {
					process.Wait ();
					int exitCode = process.Result;
					if (exitCode != 0)
						Log.LogError ($"{program} returned exit code {exitCode} unexpectingly. See error for more details:\n{stderr.ToString()}");
					return exitCode;
				}	
			}
		}

		void FixXamWrappingReferences (string libraryPath)
		{
			// XamWrapping has a reference to XamGlue and not @rpath/XamGlue which won't search the framework next door
			if (Run ("/usr/bin/install_name_tool", $"-change XamGlue @executable_path/../Frameworks/XamGlue.framework/XamGlue {libraryPath}") != 0)
				return;

			// XamWrapping has a reference to the original swift rpath
			string swiftAddedRPath = ToolPath.Substring (0, ToolPath.Length - 13 /*swift-o-matic*/) + "bin/swift/lib/swift/macosx";
			if (Run ("/usr/bin/install_name_tool", $"-delete_rpath {swiftAddedRPath} {libraryPath}") != 0)
				return;
		}

		public override bool Execute ()
		{
			string libraryPath = CreateXamWrappingFramework ("XamWrapping");
			if (libraryPath == null)
				return false;
			FixXamWrappingReferences (libraryPath);

			return !Log.HasLoggedErrors;
		}
	}
}
