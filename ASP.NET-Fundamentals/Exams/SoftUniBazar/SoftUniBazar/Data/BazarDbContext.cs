using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<AdBuyer> AdsBuyers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });

            builder.Entity<AdBuyer>()
                .HasKey(ab => new { ab.AdId, ab.BuyerId });

            builder.Entity<Ad>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.Entity<AdBuyer>()
                .HasOne(ab => ab.Ad)
                .WithMany(ab => ab.AdsBuyer)
                .HasForeignKey(ab => ab.AdId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}