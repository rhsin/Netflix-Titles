using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcTitle.Services
{
    public class WebClient 
    {
        public async Task<string> GetRequest(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
