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

namespace notificationCross.Droid
{
    public class GpsLocationAndroid : GpsLocation
    {
        public GpsLocationAndroid() : base()
        {

        }

        public GpsLocationAndroid(double latitude, double longitude) : base(latitude, longitude)
        {

        }

        protected override void GetCurrentLocation()
        {
            throw new NotImplementedException();
        }

    }
}