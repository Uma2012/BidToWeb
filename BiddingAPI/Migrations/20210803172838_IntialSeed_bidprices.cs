using Microsoft.EntityFrameworkCore.Migrations;

namespace BiddingAPI.Migrations
{
    public partial class IntialSeed_bidprices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BidPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdId = table.Column<int>(type: "int", nullable: false),
                    BidValue = table.Column<double>(type: "float", nullable: false),
                    AliasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidPrices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BidPrices",
                columns: new[] { "Id", "AliasId", "BidValue", "ProdId" },
                values: new object[,]
                {
                    { 1, 1, 500.0, 1 },
                    { 2, 2, 500.0, 1 },
                    { 3, 1, 100.0, 2 },
                    { 4, 1, 10.0, 3 },
                    { 5, 1, 200.0, 4 },
                    { 6, 2, 5.0, 3 },
                    { 7, 1, 1000.0, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidPrices");
        }
    }
}
