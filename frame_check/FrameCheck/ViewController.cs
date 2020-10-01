using Foundation;
using System;
using UIKit;

namespace FrameCheck
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // 2020-10-01 14:57:39.650223-0500 FrameCheck[88541:7593823] 568 on 7th gen iPod touch sim
            // 2020-10-01 14:59:19.452485-0500 FrameCheck[88775:7606316] 812 on iPhone 11 Pro iOS 14 sim
            // 2020 - 10 - 01 15:02:28.036 FrameCheck[15914:7018784] 896 on iPhone 11 Pro Hardware
            Console.WriteLine(this.View.Frame.Size.Height);

            // 2020-10-01 15:02:53.898031-0500 FrameCheck[89076:7613380] 568 on 7th gen iPod touch sim
            // 2020-10-01 15:03:26.960434-0500 FrameCheck[89117:7614493] 812 on iPhone 11 Pro iOS 14 sim
            // 2020-10-01 15:04:26.490 FrameCheck[15916:7019810] 896 on iPhone 11 Pro Hardware
            Console.WriteLine(this.View.Bounds.Size.Height);

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}