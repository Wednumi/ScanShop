using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.Entities;

namespace ScanShop.Db.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<ShopUser> ShopUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ShopUser>(user =>
            {
                user.HasMany(u => u.Messages)
                    .WithOne(m => m.User)
                    .HasForeignKey(m => m.UserId);

                user.HasMany(u => u.Reviews)
                    .WithOne(r => r.User)
                    .HasForeignKey(r => r.UserId);

                user.HasMany(u => u.Orders)
                    .WithOne(o => o.User)
                    .HasForeignKey(o => o.UserId);

                user.HasMany(u => u.Saved)
                    .WithMany(p => p.UsersSaved)
                    .UsingEntity(
                        "UserSavedProduct",
                        l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId"),
                        r => r.HasOne(typeof(ShopUser)).WithMany().HasForeignKey("UserId"));

                user.HasMany(u => u.CartItems)
                    .WithMany(i => i.Users)
                    .UsingEntity(
                        "UserCart",
                        l => l.HasOne(typeof(OrderItem)).WithMany().HasForeignKey("OrderItemId"),
                        r => r.HasOne(typeof(ShopUser)).WithMany().HasForeignKey("UserId"));
            });

            builder.Entity<Order>(order =>
            {
                order.HasMany(o => o.OrderItems)
                    .WithMany(i => i.Orders)
                    .UsingEntity(
                        "OrderOrderItem",
                        l => l.HasOne(typeof(OrderItem)).WithMany().HasForeignKey("OrderItemId"),
                        r => r.HasOne(typeof(Order)).WithMany().HasForeignKey("OrderId"));
            });
        }
    }
}
