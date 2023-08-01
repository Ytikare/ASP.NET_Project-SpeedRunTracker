using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedRunTracker.Data.Migrations
{
    public partial class SeedModeratorAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6a490127-80c3-49c1-b851-a6a24be09ec7"), 0, "bd00ab02-3449-45bc-88c0-4582d58a147b", "moderator@mod.com", false, true, null, "MODERATOR@MOD.COM", "MODERATOR", "AQAAAAEAACcQAAAAEMnyeOwW3ebfuZp0Ffs+zwn4N05jnXVXy7bK1mjoDydXgZexJdbe5lWsJgXflVSRNw==", null, false, "OBY4VDKW34POTHNHYJIASQW3MTGIOR42", false, "Moderator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), 0, "bfb3560c-3135-47b4-aa22-f7903def1f7d", "user@users.com", false, true, null, "USER@USERS.COM", "USER", "AQAAAAEAACcQAAAAEB3MVjgCt8z3Kiu4qTg1LsJgiQeM5nUYI6rDnSNJ5SCDMzktBmzmo8JzMq0MdcxKjA==", null, false, "TSNRHBY6H2J4FRYTZVNRTHASL2OAI6LB", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3af205a4-079e-4464-8004-cfa98ffc3bb7"), new Guid("6a490127-80c3-49c1-b851-a6a24be09ec7") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("bd04980a-4718-47df-8a05-db07d6d91458"), new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3af205a4-079e-4464-8004-cfa98ffc3bb7"), new Guid("6a490127-80c3-49c1-b851-a6a24be09ec7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bd04980a-4718-47df-8a05-db07d6d91458"), new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a490127-80c3-49c1-b851-a6a24be09ec7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"));
        }
    }
}
