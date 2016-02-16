using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using notificationCross;

namespace notificationCross.Droid
{
	[Activity (Label = "notificationCross.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, ILocationListener
	{
        Person person;
        EditText nameEditText;
        EditText surnameEditText;
        LocationManager locM;
        Location gpsLocation;
        Button[] notificationButtons;
        TextView textView;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            nameEditText = FindViewById<EditText>(Resource.Id.firstNameTextField);
            surnameEditText = FindViewById<EditText>(Resource.Id.surNameTextField);

            locM = GetSystemService(Context.LocationService) as LocationManager;
            if (locM.IsProviderEnabled(LocationManager.GpsProvider))
                locM.RequestLocationUpdates(LocationManager.GpsProvider, 2000, 1, this);


            Button notificationButton1 = FindViewById<Button>(Resource.Id.notificationButton1);
            Button notificationButton2 = FindViewById<Button>(Resource.Id.notificationbutton2);
            Button notificationButton3 = FindViewById<Button>(Resource.Id.notificationbutton3);
            Button notificationButton4 = FindViewById<Button>(Resource.Id.notificationbutton4);
            Button notificationButton5 = FindViewById<Button>(Resource.Id.notificationbutton5);
            textView = FindViewById<TextView>(Resource.Id.textView2);


            notificationButtons = new Button[] { notificationButton1, notificationButton2, notificationButton3, notificationButton4, notificationButton5 };

            foreach (Button button in notificationButtons)
            {
                button.Enabled = false;
                button.Click += SendNotification;
            }            
		}

        private async void SendNotification(object sender, EventArgs e)
        {
            EditText nameEditText = FindViewById<EditText>(Resource.Id.firstNameTextField);
            EditText surnameEditText = FindViewById<EditText>(Resource.Id.surNameTextField);
            person = new Person(nameEditText.Text, surnameEditText.Text);
            Button button = sender as Button;
            Console.WriteLine("Button {0} pressed", button.Text);
          
            DataUpload dataUploader = new DataUpload("http://pluton.kt.agh.edu.pl/~ppiatek/jpwp/api.php");
            bool result = await dataUploader.SendJSON(new NotificationData(person, (NotificationLevel)Convert.ToInt32(button.Text), new GpsLocationAndroid(gpsLocation)));
            if (result)
                ShowAlertDialog("Sukces", "Zgłoszenie zostało wysłane na serwer");
            else
                ShowAlertDialog("Brak dostępu do Internetu", "Znajdź dostęp do sieci i spróbuj ponownie");
        }

        private void ShowAlertDialog(string name, string text)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog dialog = builder.Create();
            dialog.SetTitle(name);
            dialog.SetMessage(text);
            dialog.SetButton("OK", (object s, DialogClickEventArgs ev) => { });
            dialog.Show();
        }

        private void ModifyLocation()
        {
            nameEditText.Text = "25";
            surnameEditText.Text = "30";
        }

        public void OnLocationChanged(Location location)
        {
            textView.Text = "Wybierz Zgloszenie:";
            gpsLocation = location;
            Console.WriteLine(location.Latitude + "    " + location.Longitude);
            foreach (Button button in notificationButtons)
                button.Enabled = true;
        }

        public void OnProviderDisabled(string provider)
        {
            
        }

        public void OnProviderEnabled(string provider)
        {
            
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            
        }
    }
}


