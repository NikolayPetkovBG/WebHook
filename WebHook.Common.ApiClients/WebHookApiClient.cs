using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebHook.Common.Models;

namespace WebHook.Common.ApiClients
{
    public class WebHookApiClient : IWebHookApiClient
    {
        //TODO: consider using "global" HttpClient with DI
        private readonly HttpClient _httpCleint; 

        public WebHookApiClient(string baseURL)
        {
            _httpCleint = new HttpClient()
            {
                BaseAddress = new Uri(baseURL)
            };
        }

        public async Task<Models.WebHook> AddWebHookAsync(Models.WebHook webHook)
        {
            // TODO: Add error handling
            HttpResponseMessage response = await _httpCleint.PostAsJsonAsync(Constants.CreateURL, webHook);

            //response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Models.WebHook>();
        }

        public async Task CallWebHookAsync(int id)
        {
            // TODO: Test the real web hook invocation
            await _httpCleint.PostAsync(string.Format(Constants.CallURL, id), null);
        }

        public async Task<IEnumerable<Models.WebHook>> GetAllWebHooksAsync()
        {
            return await _httpCleint.GetFromJsonAsync<IEnumerable<Models.WebHook>>(Constants.ListURL);
        }
    }
}
