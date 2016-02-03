// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace notificationCross.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField nameTextFirld { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton notificationButton1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton notificationButton2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton notificationButton3 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton notificationButton4 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton notificationButton5 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField sureNameTextField { get; set; }

		[Action ("notificationButton1TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void notificationButton1TouchUpInside (UIButton sender);

		[Action ("notificationButton2TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void notificationButton2TouchUpInside (UIButton sender);

		[Action ("notificationButton3TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void notificationButton3TouchUpInside (UIButton sender);

		[Action ("notificationButton4TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void notificationButton4TouchUpInside (UIButton sender);

		[Action ("notificationButton5TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void notificationButton5TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (nameTextFirld != null) {
				nameTextFirld.Dispose ();
				nameTextFirld = null;
			}
			if (notificationButton1 != null) {
				notificationButton1.Dispose ();
				notificationButton1 = null;
			}
			if (notificationButton2 != null) {
				notificationButton2.Dispose ();
				notificationButton2 = null;
			}
			if (notificationButton3 != null) {
				notificationButton3.Dispose ();
				notificationButton3 = null;
			}
			if (notificationButton4 != null) {
				notificationButton4.Dispose ();
				notificationButton4 = null;
			}
			if (notificationButton5 != null) {
				notificationButton5.Dispose ();
				notificationButton5 = null;
			}
			if (sureNameTextField != null) {
				sureNameTextField.Dispose ();
				sureNameTextField = null;
			}
		}
	}
}
