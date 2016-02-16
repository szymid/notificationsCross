using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace notificationCross
{
    public class DataUpload
    {
        private HttpWebRequest httpWebRequest;

        public DataUpload(string url)
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
        }

        async public Task<bool> SendJSON(NotificationData data)
        {
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            try
            {
                Task<Stream> task = httpWebRequest.GetRequestStreamAsync();
                Stream stream = task.Result;
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string jsonString = data.FormatJSONtoString();
                    writer.Write(jsonString);
                    writer.Flush();
                }
                WebResponse httpWebResponse = await httpWebRequest.GetResponseAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

