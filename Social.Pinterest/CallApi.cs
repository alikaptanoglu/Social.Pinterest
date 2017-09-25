using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Social.Pinterest
{
    class CallApi
    {
        public string Post(string url, string data)
        {
            string json = null;
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                //  req.Accept = "application/json";
                using (var stream = req.GetRequestStream())
                {
                    byte[] bindata = Encoding.ASCII.GetBytes(data);
                    stream.Write(bindata, 0, bindata.Length);
                }
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                string response = new StreamReader(resp.GetResponseStream()).ReadToEnd();

                return response;
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            return json;

                        }
                    }
                }
            }
            return json;
        }

        public string Get(string url)
        {
            string json = null;
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.Accept = "application/json";
                
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                json = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                
                return json;
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            return json;

                        }
                    }
                }
            }
            return json;
        }
        
    }
}
