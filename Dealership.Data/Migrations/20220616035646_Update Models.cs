using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Generation",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Cars",
                newName: "Brand");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                schema: "Identity",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Decription",
                table: "CarsForSale",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateJoined",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Decription",
                table: "CarsForSale");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Cars",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Generation",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
