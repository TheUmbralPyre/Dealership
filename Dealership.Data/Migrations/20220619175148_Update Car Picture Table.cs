using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class UpdateCarPictureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPicture_Cars_CarId",
                table: "CarPicture");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "CarPicture");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "CarPicture");

            migrationBuilder.RenameColumn(
                name: "Slide",
                table: "CarPicture",
                newName: "GeneralPath");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarPicture",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPicture_Cars_CarId",
                table: "CarPicture",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPicture_Cars_CarId",
                table: "CarPicture");

            migrationBuilder.RenameColumn(
                name: "GeneralPath",
                table: "CarPicture",
                newName: "Slide");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarPicture",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "CarPicture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "CarPicture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPicture_Cars_CarId",
                table: "CarPicture",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
