using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPI.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BasePrice", "Description", "ImageUrl", "IsSold", "ProductName", "RemainingDays" },
                values: new object[,]
                {
                    { 1, 1000.0, "Classic style", "image/Cabinet.jpg", false, "Cabinet", 3 },
                    { 2, 2000.0, "Well maintained cycle", "image/Cycle.jpg", false, "Cycle", 1 },
                    { 3, 150.0, "Brio train", "image/GardenTools.jpg", false, "Toys", 5 },
                    { 4, 5000.0, "Super powerful garden maintainer", "image/Toys.jpg", false, "GardenTools", 2 },
                    { 5, 200.0, "Iron pan", "image/Vessel.jpg", false, "Vessels", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
