using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedRunTracker.Data.Migrations
{
    public partial class CreateAndSeedSupportTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IssuerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeclined = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTickets_AspNetUsers_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SupportTickets",
                columns: new[] { "Id", "Content", "IsActive", "IsDeclined", "IssueDate", "IssuerId", "Title" },
                values: new object[] { new Guid("921296be-33ca-4853-887c-7c5cea0e0f2b"), "I request the game Only Up! to be added. since it has a large speedrunning commynity around it.", true, false, new DateTime(2023, 7, 3, 10, 50, 40, 0, DateTimeKind.Local), new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), "Requseting new game to be added - Only Up!" });

            migrationBuilder.InsertData(
                table: "SupportTickets",
                columns: new[] { "Id", "Content", "IsActive", "IsDeclined", "IssueDate", "IssuerId", "Title" },
                values: new object[] { new Guid("f808b07a-fb80-414e-b24a-ce392cb91729"), "Most of my speedruns have not been verified. Since all of them are valid, would you verify them, please?", true, false, new DateTime(2023, 7, 14, 10, 50, 40, 0, DateTimeKind.Local), new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), "Requesting speedrun verification" });

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_IssuerId",
                table: "SupportTickets",
                column: "IssuerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportTickets");
        }
    }
}
