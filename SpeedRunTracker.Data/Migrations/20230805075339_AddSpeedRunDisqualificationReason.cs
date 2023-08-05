using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedRunTracker.Data.Migrations
{
    public partial class AddSpeedRunDisqualificationReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisqualificationReason",
                table: "SpeedRuns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("099c2308-7931-4b24-a6ec-96505ed3e1c8"),
                column: "SubmitionDate",
                value: new DateTime(2022, 2, 14, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("164f8ec8-5096-4731-8a7d-fb0264edf0bc"),
                column: "SubmitionDate",
                value: new DateTime(2023, 7, 8, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("1fbc13b9-a4ee-4807-84a7-693acdc12bfb"),
                column: "SubmitionDate",
                value: new DateTime(2021, 6, 20, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("3fe0fe8c-fe75-4ab9-9f7f-1d43a281c92a"),
                column: "SubmitionDate",
                value: new DateTime(2020, 7, 13, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("6d9d8faa-59a2-4a4f-82b8-3d8be04a2a37"),
                column: "SubmitionDate",
                value: new DateTime(2021, 10, 19, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("6e5b4681-5cfb-4d1b-9192-400a5d4a05f7"),
                column: "SubmitionDate",
                value: new DateTime(2023, 1, 23, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("751f9621-3919-46f8-b5ed-fd6343bc5433"),
                column: "SubmitionDate",
                value: new DateTime(2022, 9, 7, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("78c800e3-ad7b-4ef4-950b-cb48eef15b64"),
                column: "SubmitionDate",
                value: new DateTime(2023, 7, 1, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("7b848c6b-7722-43b9-970e-cfd8b38bcf51"),
                column: "SubmitionDate",
                value: new DateTime(2022, 11, 12, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("8e3c8352-0b2b-47b0-a95e-fdc9d7833ade"),
                column: "SubmitionDate",
                value: new DateTime(2023, 7, 12, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("b1602b03-db0f-4d4b-b8ae-869dc7c36b8f"),
                column: "SubmitionDate",
                value: new DateTime(2023, 5, 3, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("bbd08a56-d96d-4972-88fc-b028bd52aab0"),
                column: "SubmitionDate",
                value: new DateTime(2022, 5, 3, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("c3ca6c60-2cd1-464c-bd4a-8d01837be2ac"),
                column: "SubmitionDate",
                value: new DateTime(2020, 5, 24, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("c50261bd-22d4-4091-9451-766391ed78f0"),
                column: "SubmitionDate",
                value: new DateTime(2022, 7, 5, 10, 50, 40, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("e4fd2f72-a0bc-47d4-89a4-fea6472da5e6"),
                column: "SubmitionDate",
                value: new DateTime(2022, 8, 12, 10, 50, 40, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisqualificationReason",
                table: "SpeedRuns");

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("099c2308-7931-4b24-a6ec-96505ed3e1c8"),
                column: "SubmitionDate",
                value: new DateTime(2022, 2, 10, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("164f8ec8-5096-4731-8a7d-fb0264edf0bc"),
                column: "SubmitionDate",
                value: new DateTime(2023, 7, 4, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("1fbc13b9-a4ee-4807-84a7-693acdc12bfb"),
                column: "SubmitionDate",
                value: new DateTime(2021, 6, 16, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("3fe0fe8c-fe75-4ab9-9f7f-1d43a281c92a"),
                column: "SubmitionDate",
                value: new DateTime(2020, 7, 9, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9739));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("6d9d8faa-59a2-4a4f-82b8-3d8be04a2a37"),
                column: "SubmitionDate",
                value: new DateTime(2021, 10, 15, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("6e5b4681-5cfb-4d1b-9192-400a5d4a05f7"),
                column: "SubmitionDate",
                value: new DateTime(2023, 1, 19, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("751f9621-3919-46f8-b5ed-fd6343bc5433"),
                column: "SubmitionDate",
                value: new DateTime(2022, 9, 3, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("78c800e3-ad7b-4ef4-950b-cb48eef15b64"),
                column: "SubmitionDate",
                value: new DateTime(2023, 6, 27, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("7b848c6b-7722-43b9-970e-cfd8b38bcf51"),
                column: "SubmitionDate",
                value: new DateTime(2022, 11, 8, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9572));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("8e3c8352-0b2b-47b0-a95e-fdc9d7833ade"),
                column: "SubmitionDate",
                value: new DateTime(2023, 7, 8, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("b1602b03-db0f-4d4b-b8ae-869dc7c36b8f"),
                column: "SubmitionDate",
                value: new DateTime(2023, 4, 29, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("bbd08a56-d96d-4972-88fc-b028bd52aab0"),
                column: "SubmitionDate",
                value: new DateTime(2022, 4, 29, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("c3ca6c60-2cd1-464c-bd4a-8d01837be2ac"),
                column: "SubmitionDate",
                value: new DateTime(2020, 5, 20, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9629));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("c50261bd-22d4-4091-9451-766391ed78f0"),
                column: "SubmitionDate",
                value: new DateTime(2022, 7, 1, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "SpeedRuns",
                keyColumn: "Id",
                keyValue: new Guid("e4fd2f72-a0bc-47d4-89a4-fea6472da5e6"),
                column: "SubmitionDate",
                value: new DateTime(2022, 8, 8, 19, 3, 28, 583, DateTimeKind.Utc).AddTicks(9704));
        }
    }
}
