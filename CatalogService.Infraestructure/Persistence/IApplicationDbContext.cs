using Microsoft.EntityFrameworkCore;
using CatalogService.Domain;

namespace CatalogService.Infraestructure.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<Item> Item { get; set; }
    }
}
