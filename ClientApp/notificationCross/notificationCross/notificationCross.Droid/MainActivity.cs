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
        private string name;
        private string surname;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            EditText nameEditText = FindViewById<EditText>(Resource.Id.firstNameTextField);
            EditText surnameEditText = FindViewById<EditText>(Resource.Id.surNameTextField);


            Button notificationButton1 = FindViewById<Button>(Resource.Id.notificationButton1);
            Button notificationButton2 = FindViewById<Button>(Resource.Id.notificationbutton2);
            Button notificationButton3 = FindViewById<Button>(Resource.Id.notificationbutton3);
            Button notificationButton4 = FindViewById<Button>(Resource.Id.notificationbutton4);
            Button notificationButton5 = FindViewById<Button>(Resource.Id.notificationbutton5);

            Button[] notificationButtons = { notificationButton1, notificationButton2, notificationButton3, notificationButton4, notificationButton5 };

            foreach (Button button in notificationButtons)
                button.Click += SendNotification;            
		}

        private void SendNotification(object sender, EventArgs e)
        {
            EditText nameEditText = FindViewById<EditText>(Resource.Id.firstNameTextField);
            EditText surnameEditText = FindViewById<EditText>(Resource.Id.surNameTextField);
            person = new Person(nameEditText.Text, surnameEditText.Text);
            Button button = sender as Button;
            Console.WriteLine("Button {0} pressed", button.Text);
            DataUpload dataUploader = new DataUpload("http://pluton.kt.agh.edu.pl/~ppiatek/jpwp/api.php");
            dataUploader.SendJSON(new NotificationData(person, (NotificationLevel)Convert.ToInt32(button.Text), new GpsLocationAndroid(10, 20)));
            button.Text = "Notification Sent!";
        }

  
	}
}


