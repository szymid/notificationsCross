using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace notificationCross
{

    public enum NotificationLevel
    {
        Low = 0,
        MiddleLow = 1,
        Middle = 2,
        MiddleHigh = 3,
        High = 4
    }

    public class NotificationData
    {
        private Dictionary<string, string> dictionaryJson;

        public NotificationData(Person person, NotificationLevel notificationLevel, GpsLocation gpsLocation)
        {
            dictionaryJson = new Dictionary<string, string>();
            dictionaryJson.Add("Name", person.Name);
            dictionaryJson.Add("Surname", person.Surname);
            dictionaryJson.Add("Notification", ((int)notificationLevel).ToString());
            dictionaryJson.Add("Latitude", gpsLocation.Latitude.ToString());
            dictionaryJson.Add("Longitude", gpsLocation.Longitude.ToString());
        }

        public string FormatJSONtoString()
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("{\n");
            foreach (KeyValuePair<string, string> element in dictionaryJson)
                jsonString.Append(String.Format("\"{0}\" : \"{1}\",\n", element.Key, element.Value));
            jsonString.Remove(jsonString.Length - 2, 1);
            jsonString.Append("}");
            return jsonString.ToString();
        }
    }
}
