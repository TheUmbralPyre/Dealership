using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Data.Migrations
{
    public partial class RevertAttemptDecimalPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Displacement",
                table: "Engines",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(4)",
                oldPrecision: 4,
                oldScale: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Displacement",
                table: "Engines",
                type: "float(4)",
                precision: 4,
                scale: 1,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
