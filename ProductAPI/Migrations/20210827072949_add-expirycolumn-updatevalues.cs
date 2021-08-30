using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPI.Migrations
{
    public partial class addexpirycolumnupdatevalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 25, 9, 29, 49, 427, DateTimeKind.Local).AddTicks(8870), new DateTime(2021, 8, 30, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(3397), new DateTime(2021, 8, 27, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(3932) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate", "RemainingDays", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 27, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4392), new DateTime(2021, 9, 1, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4403), 5, new DateTime(2021, 8, 27, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4406) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ExpiryDate", "RemainingDays", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 26, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4410), new DateTime(2021, 8, 31, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4413), 4, new DateTime(2021, 8, 27, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ExpiryDate", "RemainingDays", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 23, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4419), new DateTime(2021, 8, 28, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4422), 1, new DateTime(2021, 8, 27, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ExpiryDate", "RemainingDays", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 24, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4428), new DateTime(2021, 8, 29, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4430), 2, new DateTime(2021, 8, 27, 9, 29, 49, 430, DateTimeKind.Local).AddTicks(4432) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Products");

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
                columns: new[] { "CreatedDate", "RemainingDays", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 15, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6509), 1, new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "RemainingDays", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 11, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6525), 5, new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "RemainingDays", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 14, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6531), 2, new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "RemainingDays", "TodaysDate" },
                values: new object[] { new DateTime(2021, 8, 13, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6536), 3, new DateTime(2021, 8, 16, 19, 27, 11, 65, DateTimeKind.Local).AddTicks(6539) });
        }
    }
}
