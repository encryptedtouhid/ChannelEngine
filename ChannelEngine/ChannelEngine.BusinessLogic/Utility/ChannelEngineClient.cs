using ChannelEngine.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChannelEngine.Business.Utility
{
    public class ChannelEngineClient
    {
        static readonly string  EndPointUrl = "https://api-dev.channelengine.net/api/v2/";
        static readonly string ApiKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
       
        public static async Task<string> GetOrderDataAsync(Search searchPeram)
        {
            string ActionUrl = "/orders/new";
            string Url = EndPointUrl + ActionUrl;         
            using var client = new HttpClient();
            searchPeram.ApiKey = ApiKey;
            string ApiEndPointURl = Url + GetQueryString(searchPeram); ;
            var response = await client.GetAsync(Url);
            return response.Content.ReadAsStringAsync().Result; ;
        }

        public static string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
}
