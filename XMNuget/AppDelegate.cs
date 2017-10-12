using AppKit;
using Foundation;

namespace XMNuget
{
	[Register("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate
	{
		public AppDelegate()
		{
		}

		public override void DidFinishLaunching(NSNotification notification)
		{
			System.Console.WriteLine(typeof(Microsoft.CodeAnalysis.CSharp.CSharpCommandLineArguments));
			System.Console.WriteLine(new System.ValueTuple<int, int> (2,2));
		}

		public override void WillTerminate(NSNotification notification)
		{
			// Insert code here to tear down your application
		}
	}
}
