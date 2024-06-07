using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBuying.Migrations
{
    public partial class initdb8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "District", "Province", "Street", "Ward" },
                values: new object[] { "Quận 7", "HCMC", "Nguyễn Thị Thập", "Tân Phong" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "District", "Province", "Street", "Ward" },
                values: new object[] { "Quận 7", "HCMC", "Lê Văn Lương", "Tân Phong" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURL",
                value: "Beautiful_House.png");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageURL",
                value: "Cozy Cottage.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "District", "Province", "Street", "Ward" },
                values: new object[] { "District A", "Province X", "123 Main St", "Ward 1" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "District", "Province", "Street", "Ward" },
                values: new object[] { "District B", "Province Y", "456 Oak St", "Ward 2" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURL",
                value: "");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageURL",
                value: "");
        }
    }
}
