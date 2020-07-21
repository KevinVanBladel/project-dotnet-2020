using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_dotnet.Data.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Hoeveelheid",
                table: "Wedstrijd",
                type: "decimal(10,3)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "Hoeveelheid",
                table: "Training",
                type: "decimal(10,3)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Eenheid",
                table: "Activiteit",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hoeveelheid",
                table: "Training");

            migrationBuilder.AlterColumn<double>(
                name: "Hoeveelheid",
                table: "Wedstrijd",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Eenheid",
                table: "Activiteit",
                type: "decimal(10,3)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
