using ChannelEngine.Business.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChannelEngine.Business.Utility
{
    public class ChannelEngineClient
    {
        static readonly string  EndPodoubleUrl = "https://api-dev.channelengine.net/api/v2";
        static readonly string ApiKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
       

        public static async Task<string> GetOrderDataAsync(Search searchPeram)
        {
            string ActionUrl = "/orders";
            string Url = EndPodoubleUrl + ActionUrl;         
            searchPeram.ApiKey = ApiKey;
            string ApiEndPodoubleURl = Url +"?"+ GetQueryString(searchPeram); ;

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, ApiEndPodoubleURl);

            var productValue = new ProductInfoHeaderValue("ChannelEngineApiClient", "1.0");
            request.Headers.UserAgent.Add(productValue);
            var resp = await httpClient.SendAsync(request);

            return await resp.Content.ReadAsStringAsync();
        }

        public static string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
        public static async Task<string> UpdateProductStockDataAsync(Search searchPeram, StockField stockField)
        {
            string ActionUrl = "/offer/stock";
            string Url = EndPodoubleUrl + ActionUrl;

            searchPeram.ApiKey = ApiKey;
            string ApiEndPodoubleURl = Url + "?" + GetQueryString(searchPeram); ;

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, ApiEndPodoubleURl);

            var productValue = new ProductInfoHeaderValue("ChannelEngineApiClient", "1.0");
            request.Headers.UserAgent.Add(productValue);

            httpClient.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header


            string company = "[" + JsonConvert.SerializeObject(stockField) + "]";
            var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(ApiEndPodoubleURl, requestContent);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
