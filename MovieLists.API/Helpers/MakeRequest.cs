using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLists.API.Helpers
{
    public static class ApiRequest
    {

        public static async Task<string> Make(Uri uri, string endpoint)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var response = await client.GetAsync(endpoint);
                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException httpRequestException)
                {
                    //TODO log the request exception
                    throw new Exception(httpRequestException.Message);
                }
            }
        }
    }
}
