using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class CreateRelationshipsBetweenTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarPictureThumbnail_CarThumbnailId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsForSale_Cars_CarId",
                table: "CarsForSale");

            migrationBuilder.DropIndex(
                name: "IX_CarsForSale_CarId",
                table: "CarsForSale");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarThumbnailId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarThumbnailId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarForSaleId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "CarPictureThumbnail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarForSaleId",
                table: "Cars",
                column: "CarForSaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarPictureThumbnail_CarId",
                table: "CarPictureThumbnail",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPictureThumbnail_Cars_CarId",
                table: "CarPictureThumbnail",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarsForSale_CarForSaleId",
                table: "Cars",
                column: "CarForSaleId",
                principalTable: "CarsForSale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPictureThumbnail_Cars_CarId",
                table: "CarPictureThumbnail");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarsForSale_CarForSaleId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarForSaleId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarPictureThumbnail_CarId",
                table: "CarPictureThumbnail");

            migrationBuilder.DropColumn(
                name: "CarForSaleId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarPictureThumbnail");

            migrationBuilder.AddColumn<Guid>(
                name: "CarThumbnailId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarsForSale_CarId",
                table: "CarsForSale",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarThumbnailId",
                table: "Cars",
                column: "CarThumbnailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarPictureThumbnail_CarThumbnailId",
                table: "Cars",
                column: "CarThumbnailId",
                principalTable: "CarPictureThumbnail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsForSale_Cars_CarId",
                table: "CarsForSale",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
