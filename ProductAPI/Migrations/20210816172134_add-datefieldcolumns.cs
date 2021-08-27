using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPI.Migrations
{
    public partial class adddatefieldcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TodaysDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 14, 19, 21, 33, 754, DateTimeKind.Local).AddTicks(501), new DateTime(2021, 8, 16, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3358) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 16, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3839), new DateTime(2021, 8, 16, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 12, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3856), new DateTime(2021, 8, 16, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 15, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3862), new DateTime(2021, 8, 16, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3865) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 14, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3867), new DateTime(2021, 8, 16, 19, 21, 33, 756, DateTimeKind.Local).AddTicks(3870) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TodaysDate",
                table: "Products");
        }
    }
}
