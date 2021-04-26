using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;

namespace WebHook.Backend.DAL
{
    public class WebHookDbContext : DbContext
    {
        //public WebHookDbContext() : base ()
        //{
        //}

        public WebHookDbContext(DbContextOptions<WebHookDbContext> options) : base (options)
        {
            this.Database.EnsureCreated();
        }

        ////protected override void OnConfiguring(DbContextOptionsBuilder options)
        ////   => options.UseSqlite("Data Source=entertainment.db");

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //   => options.UseSqlServer("Data Source =localhost\\SQLEXPRESS;Initial Catalog=WebHookDB;Integrated Security=True");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
#if DEBUG
            // Seed test data
            modelBuilder.Entity<Models.WebHook>()
                .HasData(new Models.WebHook()
                {
                    Id=1,
                    Name = "Google",
                    Url = "http:\\google.com"
                });
#endif
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.WebHook> WebHooks { get; set; }
    }
}
