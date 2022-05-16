using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P224FirstApi.DAL.Migrations
{
    public partial class CratedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 240, DateTimeKind.Utc).AddTicks(887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 561, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Products",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 240, DateTimeKind.Utc).AddTicks(1619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 561, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 237, DateTimeKind.Utc).AddTicks(1578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 557, DateTimeKind.Utc).AddTicks(5576));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 243, DateTimeKind.Utc).AddTicks(5591)),
                    UpdatedAt = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 243, DateTimeKind.Utc).AddTicks(5903)),
                    DeletedAt = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 243, DateTimeKind.Utc).AddTicks(6072)),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 561, DateTimeKind.Utc).AddTicks(9139),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 240, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 561, DateTimeKind.Utc).AddTicks(9798),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 240, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 5, 12, 17, 30, 8, 557, DateTimeKind.Utc).AddTicks(5576),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 5, 13, 15, 43, 25, 237, DateTimeKind.Utc).AddTicks(1578));
        }
    }
}
