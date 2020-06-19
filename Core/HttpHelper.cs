using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniAppHakaton.Core
{
    public class HttpHelper
    {
        public string Adress { get; set; }
        private readonly IHttpClientFactory _clientFactory;
    
        public HttpHelper(string adress, IHttpClientFactory clientFactory)
        {
            Adress = adress;
            _clientFactory = clientFactory;
        }
        public HttpRequestMessage SendGet(string metod, Dictionary<string, string> values)
        {
            var requestLine = Adress + metod + ((values.Count > 0) ? "?" : "");
            foreach (var item in values)
            {
                requestLine += $"{item.Key}={item.Value}";
            }
            requestLine = requestLine.Substring(0, ((values.Count > 0) ? requestLine.Count() - 1 : requestLine.Count()));

            return new HttpRequestMessage(HttpMethod.Get, requestLine);
        }
        public HttpRequestMessage SendPost<T>(string metod, T values)
        {
            var serilisedData = Regex.Unescape(JsonSerializer.Serialize(values, new JsonSerializerOptions() { IgnoreNullValues = true }));
            var request = new HttpRequestMessage(HttpMethod.Post,
            $"{Adress}{metod}")
            {
                Content = new StringContent(serilisedData,
                                    Encoding.UTF8,
                                    "application/json")
            };
            return request;
        }
       
        public async Task<HttpResponseMessage> SendHttpRequestMessageBody(HttpRequestMessage httpRequestMessage)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.SendAsync(httpRequestMessage);
        }
        public async Task<CookieCollection> SendHttpRequestMessageCookie(HttpRequestMessage httpRequestMessage)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            HttpClient client = new HttpClient(handler);

            client.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
            CookieCollection collection = handler.CookieContainer.GetCookies(httpRequestMessage.RequestUri);
            var data = await response.Content.ReadAsStringAsync();
            int start = data.IndexOf("<auth>") + 6;
            int finish = data.IndexOf("</auth>");
            bool.TryParse(data.Substring(start, finish - start), out bool rezult);
            if (!rezult)
            {
                collection = null;
            }
            return collection;
        }
        
        public async Task<string> GetDataFromBody(HttpRequest Request)
        {
            string data;
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                data = await reader.ReadToEndAsync();
            }
            return data;
        }

    }
}
