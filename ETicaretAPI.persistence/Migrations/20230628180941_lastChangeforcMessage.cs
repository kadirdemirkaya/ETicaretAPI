using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.persistence.Migrations
{
    public partial class lastChangeforcMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "CommunicationMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "PersonMessage",
                table: "CommunicationMessages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22da9127-f4e9-491f-8440-75765eb4db4a"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c112704c-1192-42d5-b83f-8932cebb59c8"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c62e3d07-1f16-411e-be9e-a76c6ba445f0"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ca13f73e-ee19-40ca-9905-678043be4aea"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d0c3d27e-1781-46c9-87e1-2b88f48d23f2"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2b26034-015e-4414-abd6-a83c6d1e593a"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 21, 9, 41, 145, DateTimeKind.Local).AddTicks(3633));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "CommunicationMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PersonMessage",
                table: "CommunicationMessages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22da9127-f4e9-491f-8440-75765eb4db4a"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 19, 6, 5, 494, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c112704c-1192-42d5-b83f-8932cebb59c8"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 19, 6, 5, 494, DateTimeKind.Local).AddTicks(1603));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c62e3d07-1f16-411e-be9e-a76c6ba445f0"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 19, 6, 5, 494, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ca13f73e-ee19-40ca-9905-678043be4aea"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 19, 6, 5, 494, DateTimeKind.Local).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d0c3d27e-1781-46c9-87e1-2b88f48d23f2"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 19, 6, 5, 494, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2b26034-015e-4414-abd6-a83c6d1e593a"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 28, 19, 6, 5, 494, DateTimeKind.Local).AddTicks(1642));
        }
    }
}
