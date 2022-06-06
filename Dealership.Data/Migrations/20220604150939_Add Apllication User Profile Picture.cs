using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class AddApllicationUserProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                schema: "Identity",
                table: "User",
                newName: "ProfilePictureOriginal");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ProfilePictureOriginal",
                schema: "Identity",
                table: "User",
                newName: "ProfilePicture");
        }
    }
}
