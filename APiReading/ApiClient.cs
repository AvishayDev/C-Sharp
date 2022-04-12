using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APiReading
{
    public static class ApiClient
    {
        public static HttpClient HttpClient { get; set; }

        public static void InitializeHttpClient()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
