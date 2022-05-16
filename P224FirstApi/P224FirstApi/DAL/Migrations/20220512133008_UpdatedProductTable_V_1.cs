using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P224FirstApi.DAL.Migrations
{
    public partial class UpdatedProductTable_V_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 561, DateTimeKind.Utc).AddTicks(9139),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Products",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 561, DateTimeKind.Utc).AddTicks(9798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 557, DateTimeKind.Utc).AddTicks(5576),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 561, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 561, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 557, DateTimeKind.Utc).AddTicks(5576));
        }
    }
}
