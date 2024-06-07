using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBuying.Migrations
{
    public partial class initdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "District", "Province", "Street", "Ward" },
                values: new object[] { 1, "District A", "Province X", "123 Main St", "Ward 1" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "District", "Province", "Street", "Ward" },
                values: new object[] { 2, "District B", "Province Y", "456 Oak St", "Ward 2" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "AddressId", "Bathrooms", "Bedrooms", "Description", "ImageURL", "Price", "Status", "Title" },
                values: new object[] { 1, 1, 2, 3, "A wonderful place to live", "", 250000m, "AVAILABLE", "Beautiful House" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "AddressId", "Bathrooms", "Bedrooms", "Description", "ImageURL", "Price", "Status", "Title" },
                values: new object[] { 2, 2, 1, 2, "Perfect for a small family", "", 150000m, "SOLD", "Cozy Cottage" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
