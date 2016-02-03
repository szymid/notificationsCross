using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace notificationCross.Droid
{
	[Activity (Label = "notificationCross.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            Button notificationButton1 = FindViewById<Button> (Resource.Id.notificationButton1);
            Button notificationButton2 = FindViewById<Button>(Resource.Id.notificationbutton2);
            Button notificationButton3 = FindViewById<Button>(Resource.Id.notificationbutton3);
            Button notificationButton4 = FindViewById<Button>(Resource.Id.notificationbutton4);
            Button notificationButton5 = FindViewById<Button>(Resource.Id.notificationbutton5);

            notificationButton1.Click += delegate
            {
                Console.WriteLine("NotificationButton 1 Pressed");
            };

            notificationButton2.Click += delegate
            {
                Console.WriteLine("NotificationButton 2 Pressed");
            };

            notificationButton3.Click += delegate
            {
                Console.WriteLine("NotificationButton 3 Pressed");
            };

            notificationButton4.Click += delegate
            {
                Console.WriteLine("NotificationButton 4 Pressed");
            };

            notificationButton5.Click += delegate
            {
                Console.WriteLine("NotificationButton 5 Pressed");
            };

            
		}
	}
}


