using Backend_almog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend_almog.Data
{
    public class Dal : IdentityDbContext<User>
    {
        public Dal(DbContextOptions<Dal> options) : base(options) { }
        

        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryItem> DeliveryItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
