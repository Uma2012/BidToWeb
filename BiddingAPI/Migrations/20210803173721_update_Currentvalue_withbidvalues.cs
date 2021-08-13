using Microsoft.EntityFrameworkCore.Migrations;

namespace BiddingAPI.Migrations
{
    public partial class update_Currentvalue_withbidvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currentvalue",
                columns: new[] { "Id", "CurrentPrice", "ProdId" },
                values: new object[,]
                {
                    { 6, 1500.0, 1 },
                    { 7, 2000.0, 1 },
                    { 8, 2100.0, 2 },
                    { 9, 160.0, 3 },
                    { 10, 5200.0, 4 },
                    { 11, 165.0, 3 },
                    { 12, 3000.0, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Currentvalue",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
