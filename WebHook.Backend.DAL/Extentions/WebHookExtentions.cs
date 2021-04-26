using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHook.Backend.DAL.Extentions
{
    // TODO: Use AutoMapper instead of this
    public static class WebHookExtentions
    {
        public static Common.Models.WebHook ToDTO (this Models.WebHook webHook)
        {
            return new Common.Models.WebHook
            {
                Id = webHook.Id,
                Name = webHook.Name,
                Url = webHook.Url
            };
        }

        public static Models.WebHook FromDTO(this Common.Models.WebHook webHook)
        {
            return new Models.WebHook
            {
                Id = webHook.Id,
                Name = webHook.Name,
                Url = webHook.Url
            };
        }
    }
}
