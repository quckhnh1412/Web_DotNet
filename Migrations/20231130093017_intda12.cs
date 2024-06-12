using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBuying.Migrations
{
    public partial class intda12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "District", "Province", "Street", "Ward" },
                values: new object[,]
                {
                    { 4, "Quận 7", "HCMC", "Số 15", "KDC Midtown" },
                    { 5, "Quận 7", "HCMC", "Số 30", "KDT Phú Mỹ Hưng" },
                    { 6, "Quận Bình Tân", "HCMC", "Số 819 Hương Lộ", "Phường Bình Trị Đông" },
                    { 7, "Thủ Đức", "HCMC", "Số 7", "Phường An Lợi Đông" },
                    { 8, "Quận 1", "HCMC", "Số 90 Nguyễn Thị Minh Khai", "Phường 5" },
                    { 9, "Quận 3", "HCMC", "Số 280 Nam Kỳ Khởi Nghĩa", "Phường 8" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "AddressId", "Bathrooms", "Bedrooms", "Description", "ImageURL", "Price", "Squarefoot", "Status", "Title" },
                values: new object[,]
                {
                    { 4, 4, 4, 5, "", "", 700000m, 8000, "AVAILABLE", "" },
                    { 5, 5, 2, 3, "", "", 470000m, 3900, "AVAILABLE", "" },
                    { 6, 6, 5, 6, "", "", 1000000m, 9000, "SOLD", "" },
                    { 7, 7, 3, 4, "", "", 550000m, 6000, "AVAILABLE", "" },
                    { 8, 8, 3, 3, "", "", 300000m, 3500, "SOLD", "" },
                    { 9, 9, 3, 4, "", "", 600000m, 5500, "AVAILABLE", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
