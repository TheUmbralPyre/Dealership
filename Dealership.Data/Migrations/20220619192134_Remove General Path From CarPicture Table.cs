using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class RemoveGeneralPathFromCarPictureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GeneralPath",
                table: "CarPicture",
                newName: "SlidePath");

            migrationBuilder.AddColumn<string>(
                name: "OriginalPath",
                table: "CarPicture",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalPath",
                table: "CarPicture");

            migrationBuilder.RenameColumn(
                name: "SlidePath",
                table: "CarPicture",
                newName: "GeneralPath");
        }
    }
}
