using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiddingAPI.Migrations
{
    public partial class IntialSeed_Aliases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdId = table.Column<int>(type: "int", nullable: false),
                    AliasId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliases", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aliases",
                columns: new[] { "Id", "AliasId", "ProdId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") },
                    { 2, 2, 1, new Guid("0c278933-2e38-4e0a-ae31-c26b6769c869") },
                    { 3, 1, 2, new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") },
                    { 4, 1, 3, new Guid("0933a144-762a-4290-af1a-435e19511232") },
                    { 5, 1, 4, new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") },
                    { 6, 2, 3, new Guid("0c278933-2e38-4e0a-ae31-c26b6769c869") },
                    { 7, 1, 1, new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliases");
        }
    }
}
