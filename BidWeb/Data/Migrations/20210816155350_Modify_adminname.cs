using Microsoft.EntityFrameworkCore.Migrations;

namespace BidWeb.Data.Migrations
{
    public partial class Modify_adminname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99174d28-2832-4ecf-90dc-a4ea100c0ea7");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46afc4f1-c22c-4f19-819e-0d454b144b22", 0, null, "be298408-4275-4242-afaa-31971a3517e8", "admin@admin.com", true, null, true, null, false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEN8cSmJ9rnag2wclhBqEIpZNv8L4Ne+Dbn+ovphkqn64GheetSAJfYIrEI0l+QRVvw==", null, false, null, "", null, false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46afc4f1-c22c-4f19-819e-0d454b144b22");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99174d28-2832-4ecf-90dc-a4ea100c0ea7", 0, null, "062163f1-3ef9-43ba-98dd-ceb37803a1de", "admin@admin.com", true, null, true, null, false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEEx2TZRWgt1Pim6VhA1CdV7fGd6ApgZPYEAd0wT2rP221TdVS1yPEdpSOvm3+4Ku5g==", null, false, null, "", null, false, "admin@admin.com" });
        }
    }
}
