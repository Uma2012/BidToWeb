using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPI.Migrations
{
    public partial class correction_on_datevalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 13, 19, 27, 11, 63, DateTimeKind.Local).AddTicks(1398), new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6019) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 15, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6509), new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 11, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6525), new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 14, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6531), new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 13, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6536), new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6539) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
