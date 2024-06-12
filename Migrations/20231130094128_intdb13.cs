using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBuying.Migrations
{
    public partial class intdb13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "In a world full of so many different house styles, it can be a little challenging just to narrow down your own home’s architectural style, let alone edit the list down to your favorite style or understand the distinctions characteristic to each house style", "Smart House.jpg", "Smart House" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "Architectural styles refers to historically derived house design categories, from Traditional to Modern. Our design style groupings are intended to reflect common use.", "House CountrySide.jpg", "House CountrySide" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "The lower level offers a secluded guest or in-law suite with a full bath, walk-in closet, and kitchen. A rec room, large family room, and exercise room on the lower level add function and convenience.", "Spacious House.jpg", "Spacious House" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "The home’s form is defined by two gabled pavilions that sit perpendicular to one another, “separated and inflected to create interstitial spaces between,” the architect said.", "South House.jpg", "South House" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "The ground floor is conceived as a singular volume with a central stair flanked by joinery defining public living spaces from private study and rumpus. ", "BWA House.jpg", "BWA House" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "Looking to build your dream home without breaking the bank? You’re in luck! Our inexpensive house plans to build offer loads of style, functionality, and most importantly, affordability.", "White House.jpg", "White House" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "", "", "" });
        }
    }
}
