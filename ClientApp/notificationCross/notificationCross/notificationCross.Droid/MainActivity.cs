using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using notificationCross;

namespace notificationCross.Droid
{
	[Activity (Label = "notificationCross.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        Person person;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            EditText nameEditText = FindViewById<EditText>(Resource.Id.firstNameTextField);
            EditText surnameEditText = FindViewById<EditText>(Resource.Id.surNameTextField);

            person = new Person(nameEditText.Text, surnameEditText.Text);

            Button notificationButton1 = FindViewById<Button>(Resource.Id.notificationButton1);
            Button notificationButton2 = FindViewById<Button>(Resource.Id.notificationbutton2);
            Button notificationButton3 = FindViewById<Button>(Resource.Id.notificationbutton3);
            Button notificationButton4 = FindViewById<Button>(Resource.Id.notificationbutton4);
            Button notificationButton5 = FindViewById<Button>(Resource.Id.notificationbutton5);

            Button[] notificationButtons = { notificationButton1, notificationButton2, notificationButton3, notificationButton4, notificationButton5 };

            foreach (Button button in notificationButtons)
                button.Click += SendNotification;

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

        private void SendNotification(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("Button {0} pressed", button.Text);
            DataUpload dataUploader = new DataUpload("someUrl");
            dataUploader.SendJSON(new NotificationData(person, (NotificationLevel)Convert.ToInt32(button.Text), new GpsLocationAndroid(10, 20)));
        }
	}
}


