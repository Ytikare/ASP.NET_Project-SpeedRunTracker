using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedRunTracker.Data.Migrations
{
    public partial class UpdatedGameImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://cdn.akamai.steamstatic.com/steam/apps/391540/header.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://cdn.cloudflare.steamstatic.com/steam/apps/71113/header.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://images.gog-statics.com/60741efd71f8d67d9ff221671c790782a82ac0bb5a73a7dc5d3f45801b3074da.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/c/c4/GTASABOX.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://cdn.akamai.steamstatic.com/steam/apps/774361/header.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "https://cdn.akamai.steamstatic.com/steam/apps/1237970/header.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://www.speedrun.com/gameasset/4d73n317/cover?v=694f4a9");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://www.speedrun.com/gameasset/4pdv0o1w/cover?v=938fb1b");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://www.speedrun.com/gameasset/3dxkj5p1/cover?v=dce92be");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://www.speedrun.com/gameasset/yo1yv1q5/cover?v=2c7ae3d");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://www.speedrun.com/gameasset/lde39mx6/cover?v=680736c");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "https://www.speedrun.com/gameasset/o6gen512/cover?v=c3c7ed4");
        }
    }
}
