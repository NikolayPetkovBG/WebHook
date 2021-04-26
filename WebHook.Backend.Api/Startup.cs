using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHook.Backend.DAL;
using WebHook.Backend.DAL.Repositories;
using WebHook.Backend.Services;

namespace WebHook.Backend.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebHook.Backend.Api", Version = "v1" });
            });

            // Configure dependencies
            services.AddTransient<IWebHookService, WebHookService>();
            //TODO: move DbConnectionString in config
            //services.AddDbContext<WebHookDbContext>(options => options.UseSqlite("Data Source = webhook.db"));
            //services.AddDbContext<WebHookDbContext>(options => options.UseInMemoryDatabase("TodoList"));
            services.AddDbContext<WebHookDbContext>(options => options.UseSqlServer("Data Source =localhost\\SQLEXPRESS;Initial Catalog=WebHookDB;Integrated Security=True"));
            services.AddTransient<IWebHookRepository, WebHookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebHook.Backend.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
