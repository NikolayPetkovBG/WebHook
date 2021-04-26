using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHook.Common.ApiClients;
using WebHook.Common.Models;

namespace WebHook.Frontend.Services
{
    public class WebHookService : IWebHookService
    {
        private readonly IWebHookApiClient _apiClient;

        public WebHookService(IWebHookApiClient apiClient)
        {
            _apiClient = apiClient;   
        }

        public async Task<Common.Models.WebHook> AddWebHookAsync(Common.Models.WebHook webHook)
        {
            return await _apiClient.AddWebHookAsync(webHook);
        }

        public async Task<IEnumerable<Common.Models.WebHook>> GetAllWebHooksAsync()
        {
            return await _apiClient.GetAllWebHooksAsync();
        }

        public async Task CallAllWebHooksAsync()
        {
            var webHooks = await _apiClient.GetAllWebHooksAsync();

            Parallel.ForEach(webHooks, async webHook =>
            {
                await _apiClient.CallWebHookAsync(webHook.Id);
            });
        }
    }
}
