using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class ChangePicturesofApplicationUsertobeStoredontheFileSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureComment",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePictureIndex",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePictureNav",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePictureOriginal",
                schema: "Identity",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureCommonPath",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureManagePath",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureNavbarPath",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureOriginalPath",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureCommonPath",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePictureManagePath",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePictureNavbarPath",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePictureOriginalPath",
                schema: "Identity",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePictureComment",
                schema: "Identity",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePictureIndex",
                schema: "Identity",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePictureNav",
                schema: "Identity",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePictureOriginal",
                schema: "Identity",
                table: "User",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
