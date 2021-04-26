using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHook.Frontend.Services
{
    public interface IWebHookService
    {
        /// <summary>
        /// Add a new WebHook
        /// </summary>
        /// <param name="webHook">The WebHook to add</param>
        /// <returns>The created WebHook</returns>
        Task<Common.Models.WebHook> AddWebHookAsync(Common.Models.WebHook webHook);


        /// <summary>
        /// Get all WebHooks
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Common.Models.WebHook>> GetAllWebHooksAsync();

        /// <summary>
        /// Ping all 
        /// </summary>
        /// <param name="webHook"></param>
        /// <returns></returns>
        Task CallAllWebHooksAsync();
    }
}
