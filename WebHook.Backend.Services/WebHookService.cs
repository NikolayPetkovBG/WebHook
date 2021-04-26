using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebHook.Backend.DAL.Repositories;
using WebHook.Backend.DAL.Extentions;
using System.Linq;
using System.Net.Http;

namespace WebHook.Backend.Services
{
    public class WebHookService : IWebHookService
    {
        private readonly IWebHookRepository _webHookRepository;
        private readonly HttpClient _httpClient;
        public WebHookService(IWebHookRepository webHookRepository)
        {
            _webHookRepository = webHookRepository;
            _httpClient = new HttpClient();
        }

        public async Task<Common.Models.WebHook> AddAsync(Common.Models.WebHook webHook)
        {
            var result = await _webHookRepository.CreateAsync(webHook.FromDTO());
            
            return result.ToDTO();
        }

        public async Task CallAsync(int id)
        {
            var webHook = await GetAsync(id);

            if (webHook != null)
            {
                // TODO: check method (GET or POST)
                var response = await _httpClient.PostAsync(new Uri(webHook.Url), null);

                response.EnsureSuccessStatusCode();                
            }
            else
            {
                // TODO: add loging and error handling
                throw new InvalidOperationException($"WebHook with id:{id} not found!");
            }    
        }

        public async Task<IEnumerable<Common.Models.WebHook>> GetAllAsync()
        {
            var result = await _webHookRepository.ListAllAsync();

            return result.Select(x => x.ToDTO());
        }

        public async Task<Common.Models.WebHook> GetAsync(int id)
        {
            var result = await _webHookRepository.GetByIdAsync(id);

            return result?.ToDTO();
        }
    }
}
