using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notificationCross
{
    public abstract class GpsLocation
    {
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }

        public GpsLocation()
        {

        }

        public GpsLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        abstract protected void GetCurrentLocation(); 
    }
}
