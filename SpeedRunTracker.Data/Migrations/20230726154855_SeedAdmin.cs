using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedRunTracker.Data.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("de5697f9-1610-4c65-986d-998a20d207ec"), 0, "f3ab34e0-8e81-40f5-bc42-365a5cac76f1", "admin@admin.com", false, true, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEHAsiq3wRGnN1Iz5IWJgkYPD3ENZaHWSyQwp6Aw7uv4Yy8dPpgbsxMQDJIMn1Dl9sw==", null, false, "MPCRSFQ7OON7DFGOA2356FQUFLAR7AMK", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b3cb43c8-0557-4f89-92ef-aab61426c85f"), new Guid("de5697f9-1610-4c65-986d-998a20d207ec") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b3cb43c8-0557-4f89-92ef-aab61426c85f"), new Guid("de5697f9-1610-4c65-986d-998a20d207ec") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("de5697f9-1610-4c65-986d-998a20d207ec"));
        }
    }
}
