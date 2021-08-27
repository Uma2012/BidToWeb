using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiddingAPI.Migrations
{
    public partial class remove_wrg_value_rowfrom_aliastbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aliases",
                keyColumn: "Id",
                keyValue: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Aliases",
                columns: new[] { "Id", "AliasId", "ProdId", "UserId" },
                values: new object[] { 7, 1, 1, new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") });
        }
    }
}
