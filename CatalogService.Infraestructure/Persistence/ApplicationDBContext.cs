using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CatalogService.Domain;
using Microsoft.Extensions.Configuration;
using System.IO;
using CatalogService.Application;

namespace CatalogService.Infraestructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        public string dbPath { get; }
        public ApplicationDBContext() 
        {
            _configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "CatalogService.Infraestructure"))
               .AddJsonFile(@"appsettings.json", false, false)
               .AddEnvironmentVariables()
               .Build();

            dbPath = _configuration["ConnectionStrings:DefaultConnection"];

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbPath);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }

    }
}
