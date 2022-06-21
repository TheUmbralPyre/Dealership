using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class AddCarPictureandCarPictureThumbnailSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPicture_Cars_CarId",
                table: "CarPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPictureThumbnail_Cars_CarId",
                table: "CarPictureThumbnail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPictureThumbnail",
                table: "CarPictureThumbnail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPicture",
                table: "CarPicture");

            migrationBuilder.RenameTable(
                name: "CarPictureThumbnail",
                newName: "CarPictureThumbnails");

            migrationBuilder.RenameTable(
                name: "CarPicture",
                newName: "CarPictures");

            migrationBuilder.RenameIndex(
                name: "IX_CarPictureThumbnail_CarId",
                table: "CarPictureThumbnails",
                newName: "IX_CarPictureThumbnails_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarPicture_CarId",
                table: "CarPictures",
                newName: "IX_CarPictures_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPictureThumbnails",
                table: "CarPictureThumbnails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPictures",
                table: "CarPictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPictures_Cars_CarId",
                table: "CarPictures",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPictureThumbnails_Cars_CarId",
                table: "CarPictureThumbnails",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPictures_Cars_CarId",
                table: "CarPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPictureThumbnails_Cars_CarId",
                table: "CarPictureThumbnails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPictureThumbnails",
                table: "CarPictureThumbnails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPictures",
                table: "CarPictures");

            migrationBuilder.RenameTable(
                name: "CarPictureThumbnails",
                newName: "CarPictureThumbnail");

            migrationBuilder.RenameTable(
                name: "CarPictures",
                newName: "CarPicture");

            migrationBuilder.RenameIndex(
                name: "IX_CarPictureThumbnails_CarId",
                table: "CarPictureThumbnail",
                newName: "IX_CarPictureThumbnail_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarPictures_CarId",
                table: "CarPicture",
                newName: "IX_CarPicture_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPictureThumbnail",
                table: "CarPictureThumbnail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPicture",
                table: "CarPicture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPicture_Cars_CarId",
                table: "CarPicture",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPictureThumbnail_Cars_CarId",
                table: "CarPictureThumbnail",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
