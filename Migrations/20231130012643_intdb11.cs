using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBuying.Migrations
{
    public partial class intdb11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "District", "Province", "Street", "Ward" },
                values: new object[] { 3, "Quận 1", "HCMC", "Nguyễn Thị Minh Khai", "Phường 5" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "AddressId", "Bathrooms", "Bedrooms", "Description", "ImageURL", "Price", "Squarefoot", "Status", "Title" },
                values: new object[] { 3, 3, 1, 3, "This modern glass house in Amagansett, New York, built in 2019 and represented by Yorgos Tsibiridis of Compass", "Modern House.jpg", 380000m, 5000, "AVAILABLE", "Modern House" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
