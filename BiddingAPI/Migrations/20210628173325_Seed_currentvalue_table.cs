using Microsoft.EntityFrameworkCore.Migrations;

namespace BiddingAPI.Migrations
{
    public partial class Seed_currentvalue_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currentvalue",
                columns: new[] { "Id", "CurrentPrice", "ProdId" },
                values: new object[,]
                {
                    { 1, 1000.0, 1 },
                    { 2, 2000.0, 2 },
                    { 3, 150.0, 3 },
                    { 4, 5000.0, 4 },
                    { 5, 200.0, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
