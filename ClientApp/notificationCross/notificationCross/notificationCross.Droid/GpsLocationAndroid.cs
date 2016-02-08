using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;

namespace notificationCross.Droid
{
    public class GpsLocationAndroid : GpsLocation, ILocationListener
    {
        private LocationManager locationManager;
        private Context context;
        public event EventHandler OnPositionChanged;

        public IntPtr Handle
        {
           get
           {
                return Handle;
           }
        }

        public GpsLocationAndroid(Context context) : base()
        {
            this.context = context;
            GetCurrentLocation();
        }

        public GpsLocationAndroid(Location location) : this(location.Latitude, location.Longitude)
        {

        }

        public GpsLocationAndroid(double latitude, double longitude) : base(latitude, longitude)
        {

        }

        protected override void GetCurrentLocation()
        {
            locationManager = context.GetSystemService(Context.LocationService) as LocationManager;
            if (locationManager.IsProviderEnabled(LocationManager.GpsProvider))
                locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 2000, 1, this);
            
        }

        public void OnLocationChanged(Location location)
        {
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            OnPositionChanged(this, new EventArgs());
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

        public void Dispose()
        {
            
        }
    }
}