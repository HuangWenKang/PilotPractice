using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.NetWork
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient httpClient = null;

        public HttpClientWrapper()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string Get(string url, KeyValuePair<string, string> headers)
        {
            string result = string.Empty;
            HttpResponseMessage res = httpClient.GetAsync(url).Result;
            res.EnsureSuccessStatusCode();
            if (res.IsSuccessStatusCode)
            {
                result = res.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        public string Post(string url, KeyValuePair<string, string> headers)
        {
            throw new NotImplementedException();
        }
    }
}
