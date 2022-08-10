using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleApp
{
    public static class HttpClientSample
    {
        private static HttpClient _httpClient;
        
        public static HttpClient HttpClient { get {
                if (_httpClient == null)
                    throw new Exception("HttpClient is not set");
                return _httpClient;
            }
        }
        
        static HttpClientSample()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7252/api/");
        }
    }
}
