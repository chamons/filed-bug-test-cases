﻿using AppKit;
using Foundation;

namespace Sample.MacFull
{
	[Register("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate
	{
		public AppDelegate()
		{
		}

		public override void DidFinishLaunching(NSNotification notification)
		{
			System.Console.WriteLine(TestLib.MyClass.Type);
			NSApplication.SharedApplication.Terminate(this);
		}

		public override void WillTerminate(NSNotification notification)
		{
			// Insert code here to tear down your application
		}
	}
}
