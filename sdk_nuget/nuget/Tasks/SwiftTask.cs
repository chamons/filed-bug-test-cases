using System;
using System.IO;
using System.Collections.Generic;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Sdk.Project.Prototype.Tasks
{
	static class StringExtensions
	{
		public static string TrimEndingSlash (this string s)
		{
			if (s.EndsWith ("/"))
				return s.Substring (0, s.Length - 1);
			return s;
		}
		
		public static string TrimLast (this string s, int count) => s.Substring (0, s.Length - count);
	}

	public class SwiftTask : ToolTask
	{
		[Required]
		public string OutputDirectory { get; set; }

		[Required]
		public string SwiftFrameworks { get; set; }

		[Required]
		public string ToolPath { get; set; }
		
		[Required]
		public string TargetFrameworkName { get; set; }

		public string AdditionalArguments { get; set; }

		protected override string ToolName => "swift-o-matic";
		protected override string GenerateFullPathToTool () => ToolPath;

		protected override bool ValidateParameters ()
		{
			return Directory.Exists (SwiftFrameworks);
		}

		protected override string GenerateCommandLineCommands ()
		{
			SwiftFrameworks = SwiftFrameworks.TrimEndingSlash ();
			string name = Path.GetFileName (SwiftFrameworks).TrimLast (10); /* sizeof (.Framework) */

			return $"-C {SwiftFrameworks} -o {OutputDirectory} {AdditionalArguments} {name}";
		}

		public override bool Execute ()
		{
			if (!base.Execute ())
				return false;
			return !Log.HasLoggedErrors;
		}

		protected override void LogEventsFromTextOutput (string singleLine, MessageImportance messageImportance)
		{
			// TODO - Swift-o-matic currently outputs message in a non-standard format and error(Bad) tricks msbuild to fail build
			// So for now just LogMessage everything that isn't obviously fatal
			if (singleLine.Contains ("Fatal"))
				Log.LogError (singleLine);
			else
				Log.LogMessage (messageImportance, "{0}", singleLine);


			// This is the more correct code we should be using
			/*
			try { // We first try to use the base logic, which shows up nicely in XS.
				base.LogEventsFromTextOutput (singleLine, messageImportance);
			}
			catch { // But when that fails, just output the message to the command line and XS will output it raw
				Log.LogMessage (messageImportance, "{0}", singleLine);
			}

			*/
		}
	}
}
