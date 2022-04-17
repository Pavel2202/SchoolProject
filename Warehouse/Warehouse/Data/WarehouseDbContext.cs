namespace Warehouse.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Warehouse.Data.Models;

    public class WarehouseDbContext : IdentityDbContext<User>
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}