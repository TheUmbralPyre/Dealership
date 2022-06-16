using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class SwitchToFileSystemStorageforCarImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarThumbnailId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarPicture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Original = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPicture_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarPictureThumbnail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPictureThumbnail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarThumbnailId",
                table: "Cars",
                column: "CarThumbnailId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPicture_CarId",
                table: "CarPicture",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarPictureThumbnail_CarThumbnailId",
                table: "Cars",
                column: "CarThumbnailId",
                principalTable: "CarPictureThumbnail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarPictureThumbnail_CarThumbnailId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarPicture");

            migrationBuilder.DropTable(
                name: "CarPictureThumbnail");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarThumbnailId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarThumbnailId",
                table: "Cars");
        }
    }
}
