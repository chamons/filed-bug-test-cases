﻿using AppKit;
using Foundation;

namespace NugetTest.Mac
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
		}

		public override void WillTerminate(NSNotification notification)
		{
			// Insert code here to tear down your application
		}
	}
}
