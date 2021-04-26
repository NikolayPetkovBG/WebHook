using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHook.Backend.DAL.Repositories
{
    public class WebHookRepository : IWebHookRepository
    {
        private readonly WebHookDbContext _dbContext;

        public WebHookRepository(WebHookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.WebHook> CreateAsync(Models.WebHook webHook)
        {
            var result = await _dbContext.WebHooks.AddAsync(webHook);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public async Task<Models.WebHook> GetByIdAsync(int id)
        {
            return await _dbContext.WebHooks.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Models.WebHook>> ListAllAsync()
        {
            try
            { 
                return await _dbContext.WebHooks.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
