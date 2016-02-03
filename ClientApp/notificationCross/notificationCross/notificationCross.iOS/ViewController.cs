using System;

using UIKit;

namespace notificationCross.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}


        partial void notificationButton1TouchUpInside(UIButton sender)
        {
            Console.WriteLine("notificationButton1 Pressed");
            new UIAlertView("Notification 1", "notificationButton1 Pressed", null, "OK", null).Show();
        }

        partial void notificationButton2TouchUpInside(UIButton sender)
        {
            Console.WriteLine("notificationButton2 Pressed");
            new UIAlertView("Notification 2", "notificationButton2 Pressed", null, "OK", null).Show();
        }

        partial void notificationButton3TouchUpInside(UIButton sender)
        {
            Console.WriteLine("notificationButton3 Pressed");
            new UIAlertView("Notification 3", "notificationButton3 Pressed", null, "OK", null).Show(); throw new NotImplementedException();
        }

        partial void notificationButton4TouchUpInside(UIButton sender)
        {
            Console.WriteLine("notificationButton4 Pressed");
            new UIAlertView("Notification 4", "notificationButton4 Pressed", null, "OK", null).Show(); throw new NotImplementedException();
        }

        partial void notificationButton5TouchUpInside(UIButton sender)
        {
            Console.WriteLine("notificationButton5 Pressed");
            new UIAlertView("Notification 5", "notificationButton5 Pressed", null, "OK", null).Show(); throw new NotImplementedException();
        }

    }
}

