using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedRunTracker.Data.Migrations
{
    public partial class SeedSpeedRuns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SpeedRuns",
                columns: new[] { "Id", "CategoryId", "GameId", "IsActive", "IsVerified", "SpeedRunTime", "SpeedRunVideoUrl", "SpeedRunerId", "SubmitionDate", "VerificationDate", "VerifierName" },
                values: new object[,]
                {
                    { new Guid("099c2308-7931-4b24-a6ec-96505ed3e1c8"), 3, 3, true, false, new TimeSpan(0, 1, 20, 42, 0), "https://youtu.be/iFIpaKxbMeI", new Guid("6a490127-80c3-49c1-b851-a6a24be09ec7"), new DateTime(2022, 2, 10, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9712), null, null },
                    { new Guid("164f8ec8-5096-4731-8a7d-fb0264edf0bc"), 3, 6, true, false, new TimeSpan(0, 1, 16, 21, 0), "https://youtu.be/0JEQh49IqJc", new Guid("6a490127-80c3-49c1-b851-a6a24be09ec7"), new DateTime(2023, 7, 4, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9753), null, null },
                    { new Guid("1fbc13b9-a4ee-4807-84a7-693acdc12bfb"), 2, 2, true, false, new TimeSpan(0, 0, 16, 37, 0), "https://youtu.be/OYmpVcgpKxc", new Guid("6a490127-80c3-49c1-b851-a6a24be09ec7"), new DateTime(2021, 6, 16, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9638), null, null },
                    { new Guid("3fe0fe8c-fe75-4ab9-9f7f-1d43a281c92a"), 3, 5, true, false, new TimeSpan(0, 0, 46, 59, 0), "https://youtu.be/kVBGRnrWhgE", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2020, 7, 9, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9739), null, null },
                    { new Guid("6d9d8faa-59a2-4a4f-82b8-3d8be04a2a37"), 3, 1, true, false, new TimeSpan(0, 1, 2, 23, 0), "https://youtu.be/U0DS3UNwM1M", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2021, 10, 15, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9614), null, null },
                    { new Guid("6e5b4681-5cfb-4d1b-9192-400a5d4a05f7"), 3, 1, true, false, new TimeSpan(0, 0, 57, 21, 0), "https://youtu.be/mO6AzhxlU6s", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2023, 1, 19, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9584), null, null },
                    { new Guid("751f9621-3919-46f8-b5ed-fd6343bc5433"), 3, 1, true, false, new TimeSpan(0, 1, 5, 0, 0), "https://youtu.be/LSRZk4jtWyc", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2022, 9, 3, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9622), null, null },
                    { new Guid("78c800e3-ad7b-4ef4-950b-cb48eef15b64"), 4, 4, true, false, new TimeSpan(0, 16, 9, 50, 0), "https://www.youtube.com/watch?v=d5sH2XgIKmA", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2023, 6, 27, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9720), null, null },
                    { new Guid("7b848c6b-7722-43b9-970e-cfd8b38bcf51"), 3, 1, true, false, new TimeSpan(0, 0, 56, 10, 0), "https://youtu.be/D4Qp-JWll7M", new Guid("de5697f9-1610-4c65-986d-998a20d207ec"), new DateTime(2022, 11, 8, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9572), null, null },
                    { new Guid("8e3c8352-0b2b-47b0-a95e-fdc9d7833ade"), 1, 5, true, false, new TimeSpan(0, 0, 14, 11, 930), "https://youtu.be/3izKku1J6XA", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2023, 7, 8, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9728), null, null },
                    { new Guid("b1602b03-db0f-4d4b-b8ae-869dc7c36b8f"), 3, 6, true, false, new TimeSpan(0, 1, 14, 19, 0), "https://youtu.be/bcSnIAnTxPA", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2023, 4, 29, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9746), null, null },
                    { new Guid("bbd08a56-d96d-4972-88fc-b028bd52aab0"), 3, 1, true, false, new TimeSpan(0, 1, 46, 58, 75), "https://www.youtube.com/watch?v=Xx0w_xFr_88", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2022, 4, 29, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9539), null, null },
                    { new Guid("c3ca6c60-2cd1-464c-bd4a-8d01837be2ac"), 1, 2, true, false, new TimeSpan(0, 0, 12, 40, 0), "https://youtu.be/yxrxUDD_4-U", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2020, 5, 20, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9629), null, null },
                    { new Guid("c50261bd-22d4-4091-9451-766391ed78f0"), 1, 1, true, false, new TimeSpan(0, 1, 2, 10, 0), "https://youtu.be/dwoImoxer40", new Guid("6a490127-80c3-49c1-b851-a6a24be09ec7"), new DateTime(2022, 7, 1, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9591), null, null },
                    { new Guid("e4fd2f72-a0bc-47d4-89a4-fea6472da5e6"), 4, 3, true, false, new TimeSpan(0, 1, 28, 14, 0), "https://youtu.be/Tds0511PfNc", new Guid("d5001448-ac7a-4666-824d-f6a48228b3b0"), new DateTime(2022, 8, 8, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9704), null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("099c2308-7931-4b24-a6ec-96505ed3e1c8"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("164f8ec8-5096-4731-8a7d-fb0264edf0bc"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("1fbc13b9-a4ee-4807-84a7-693acdc12bfb"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("3fe0fe8c-fe75-4ab9-9f7f-1d43a281c92a"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("6d9d8faa-59a2-4a4f-82b8-3d8be04a2a37"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("6e5b4681-5cfb-4d1b-9192-400a5d4a05f7"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("751f9621-3919-46f8-b5ed-fd6343bc5433"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("78c800e3-ad7b-4ef4-950b-cb48eef15b64"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("7b848c6b-7722-43b9-970e-cfd8b38bcf51"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("8e3c8352-0b2b-47b0-a95e-fdc9d7833ade"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("b1602b03-db0f-4d4b-b8ae-869dc7c36b8f"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("bbd08a56-d96d-4972-88fc-b028bd52aab0"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("c3ca6c60-2cd1-464c-bd4a-8d01837be2ac"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("c50261bd-22d4-4091-9451-766391ed78f0"));

            migrationBuilder.DeleteData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("e4fd2f72-a0bc-47d4-89a4-fea6472da5e6"));
        }
    }
}
