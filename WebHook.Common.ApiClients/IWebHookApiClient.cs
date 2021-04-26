using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHook.Common.ApiClients
{
    public interface IWebHookApiClient
    {
        /// <summary>
        /// Add a new WebHook
        /// </summary>
        /// <param name="webHook">The WebHook to add</param>
        /// <returns></returns>
        Task<Models.WebHook> AddWebHookAsync(Models.WebHook webHook);
        
        /// <summary>
        /// Get all WebHooks
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.WebHook>> GetAllWebHooksAsync();

        /// <summary>
        /// Call/Notify a WebHook
        /// </summary>
        /// <param name="id">The Id of the WebHook to notify</param>
        /// <returns></returns>
        Task CallWebHookAsync(int id);
    }
}
