using HouseBuying.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseBuying.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<House> Houses { get; set; }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Address
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "Nguyễn Thị Thập", Ward = "Tân Phong", District = "Quận 7", Province = "HCMC" },
                new Address { Id = 2, Street = "Lê Văn Lương", Ward = "Tân Phong", District = "Quận 7", Province = "HCMC" }
            );

            // Seed data for House
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    Id = 1,
                    Title = "Beautiful House",
                    Description = "A wonderful place to live",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    Price = 250000,
                    ImageURL = "Beautiful_House.png",
                    Status = "AVAILABLE",
                    AddressId = 1
                },
                new House
                {
                    Id = 2,
                    Title = "Cozy Cottage",
                    Description = "Perfect for a small family",
                    Bedrooms = 2,
                    Bathrooms = 1,
                    Price = 150000,
                    ImageURL = "Cozy Cottage.png",
                    Status = "SOLD",
                    AddressId = 2
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
