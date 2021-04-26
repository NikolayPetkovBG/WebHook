using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHook.Frontend.WebApp.Models;

namespace WebHook.Frontend.WebApp.Extentions
{
    /// TODO: Use AutoMapper instead of this
    public static class WebHookViewModelExtentions
    {
        public static Common.Models.WebHook ToDTO(this WebHookViewModel webHook)
        {
            return new Common.Models.WebHook
            {
                Id = webHook.Id,
                Name = webHook.Name,
                Url = webHook.Url
            };
        }

        public static WebHookViewModel FromDTO(this Common.Models.WebHook webHook)
        {
            return new WebHookViewModel
            {
                Id = webHook.Id,
                Name = webHook.Name,
                Url = webHook.Url
            };
        }
    }
}
