using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHook.Backend.DAL.Repositories
{
    public interface IWebHookRepository
    {
        Task<Models.WebHook> GetByIdAsync(int id);
        Task<IEnumerable<Models.WebHook>> ListAllAsync();
        Task<Models.WebHook> CreateAsync(Models.WebHook webHook);
    }
}
