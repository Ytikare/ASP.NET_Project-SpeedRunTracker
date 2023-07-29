using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedRunTracker.Data.Migrations
{
    public partial class AddedVerifierNameToSpeedRun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerifierName",
                table: "SpeedRuns",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerifierName",
                table: "SpeedRuns");
        }
    }
}
