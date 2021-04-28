using Microsoft.EntityFrameworkCore.Migrations;

namespace BidWeb.Data.Migrations
{
    public partial class addAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99174d28-2832-4ecf-90dc-a4ea100c0ea7", 0, null, "062163f1-3ef9-43ba-98dd-ceb37803a1de", "admin@admin.com", true, null, true, null, false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEEx2TZRWgt1Pim6VhA1CdV7fGd6ApgZPYEAd0wT2rP221TdVS1yPEdpSOvm3+4Ku5g==", null, false, null, "", null, false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99174d28-2832-4ecf-90dc-a4ea100c0ea7");
        }
    }
}
