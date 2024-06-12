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
                new Address { Id = 2, Street = "Lê Văn Lương", Ward = "Tân Phong", District = "Quận 7", Province = "HCMC" },
                new Address { Id = 3, Street = "Nguyễn Thị Minh Khai", Ward = "Phường 5", District = "Quận 1", Province = "HCMC" },
                new Address { Id = 4, Street = "Số 15", Ward = "KDC Midtown", District = "Quận 7", Province = "HCMC" },
                new Address { Id = 5, Street = "Số 30", Ward = "KDT Phú Mỹ Hưng", District = "Quận 7", Province = "HCMC" },
                new Address { Id = 6, Street = "Số 819 Hương Lộ", Ward = "Phường Bình Trị Đông", District = "Quận Bình Tân", Province = "HCMC" },
                new Address { Id = 7, Street = "Số 7", Ward = "Phường An Lợi Đông", District = "Thủ Đức", Province = "HCMC" },
                new Address { Id = 8, Street = "Số 90 Nguyễn Thị Minh Khai", Ward = "Phường 5", District = "Quận 1", Province = "HCMC" },
                new Address { Id = 9, Street = "Số 280 Nam Kỳ Khởi Nghĩa", Ward = "Phường 8", District = "Quận 3", Province = "HCMC" }
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
                    Squarefoot = 3500,
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
                    Squarefoot = 4500,
                    ImageURL = "Cozy Cottage.png",
                    Status = "SOLD",
                    AddressId = 2
                },
                new House
                {
                    Id = 3,
                    Title = "Modern House",
                    Description = "This modern glass house in Amagansett, New York, built in 2019 and represented by Yorgos Tsibiridis of Compass",
                    Bedrooms = 3,
                    Bathrooms = 1,
                    Price = 380000,
                    Squarefoot = 5000,
                    ImageURL = "Modern House.jpg",
                    Status = "AVAILABLE",
                    AddressId = 3
                },
                new House
                {
                    Id = 4,
                    Title = "Smart House",
                    Description = "In a world full of so many different house styles, it can be a little challenging just to narrow down your own home’s architectural style, let alone edit the list down to your favorite style or understand the distinctions characteristic to each house style",
                    Bedrooms = 5,
                    Bathrooms = 4,
                    Price = 700000,
                    Squarefoot = 8000,
                    ImageURL = "Smart House.jpg",
                    Status = "AVAILABLE",
                    AddressId = 4
                },
                new House
                {
                    Id = 5,
                    Title = "House CountrySide",
                    Description = "Architectural styles refers to historically derived house design categories, from Traditional to Modern. Our design style groupings are intended to reflect common use.",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    Price = 470000,
                    Squarefoot = 3900,
                    ImageURL = "House CountrySide.jpg",
                    Status = "AVAILABLE",
                    AddressId = 5
                },
                new House
                {
                    Id = 6,
                    Title = "Spacious House",
                    Description = "The lower level offers a secluded guest or in-law suite with a full bath, walk-in closet, and kitchen. A rec room, large family room, and exercise room on the lower level add function and convenience.",
                    Bedrooms = 6,
                    Bathrooms = 5,
                    Price = 1000000,
                    Squarefoot = 9000,
                    ImageURL = "Spacious House.jpg",
                    Status = "SOLD",
                    AddressId = 6
                },
                new House
                {
                    Id = 7,
                    Title = "South House",
                    Description = "The home’s form is defined by two gabled pavilions that sit perpendicular to one another, “separated and inflected to create interstitial spaces between,” the architect said.",
                    Bedrooms = 4,
                    Bathrooms = 3,
                    Price = 550000,
                    Squarefoot = 6000,
                    ImageURL = "South House.jpg",
                    Status = "AVAILABLE",
                    AddressId = 7
                },
                new House
                {
                    Id = 8,
                    Title = "BWA House",
                    Description = "The ground floor is conceived as a singular volume with a central stair flanked by joinery defining public living spaces from private study and rumpus. ",
                    Bedrooms = 3,
                    Bathrooms = 3,
                    Price = 300000,
                    Squarefoot = 3500,
                    ImageURL = "BWA House.jpg",
                    Status = "SOLD",
                    AddressId = 8
                },
                new House
                {
                    Id = 9,
                    Title = "White House",
                    Description = "Looking to build your dream home without breaking the bank? You’re in luck! Our inexpensive house plans to build offer loads of style, functionality, and most importantly, affordability.",
                    Bedrooms = 4,
                    Bathrooms = 3,
                    Price = 600000,
                    Squarefoot = 5500,
                    ImageURL = "White House.jpg",
                    Status = "AVAILABLE",
                    AddressId = 9
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
