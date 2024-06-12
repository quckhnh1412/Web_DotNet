using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBuying.Migrations
{
    public partial class intdb10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Squarefoot",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Squarefoot",
                value: 3500);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Squarefoot",
                value: 4500);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Squarefoot",
                table: "Houses");
        }
    }
}
