using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHook.Backend.Services
{
    public interface IWebHookService
    {
        Task<Common.Models.WebHook> GetAsync(int id);
        Task<IEnumerable<Common.Models.WebHook>> GetAllAsync();
        Task<Common.Models.WebHook> AddAsync(Common.Models.WebHook webHook);
        Task CallAsync(int id);

    }
}
