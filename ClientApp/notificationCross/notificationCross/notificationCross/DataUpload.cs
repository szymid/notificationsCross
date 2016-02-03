using System;
using System.Net;
using System.IO;

namespace notificationCross
{
    public class DataUpload
    {
        private HttpWebRequest httpWebRequest;

        public DataUpload(string url)
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        }

        async public void SendJSON(NotificationData data)
        {
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            using (StreamWriter writer = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                string jsonString = data.FormatJSONtoString();
                writer.Write(jsonString);
                writer.Flush();
            }
            WebResponse httpWebResponse = await httpWebRequest.GetResponseAsync();
        }
    }
}

