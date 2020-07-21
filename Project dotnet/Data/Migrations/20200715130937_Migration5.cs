using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_dotnet.Data.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GebruikerWedstrijd_Gebruiker_GebruikerId1",
                table: "GebruikerWedstrijd");

            migrationBuilder.DropForeignKey(
                name: "FK_Wedstrijd_Activiteit_ActiviteitId",
                table: "Wedstrijd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GebruikerWedstrijd",
                table: "GebruikerWedstrijd");

            migrationBuilder.DropIndex(
                name: "IX_GebruikerWedstrijd_GebruikerId1",
                table: "GebruikerWedstrijd");

            migrationBuilder.DropColumn(
                name: "GebruikerId1",
                table: "GebruikerWedstrijd");

            migrationBuilder.AlterColumn<int>(
                name: "ActiviteitId",
                table: "Wedstrijd",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GebruikerId",
                table: "GebruikerWedstrijd",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GebruikerWedstrijd",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GebruikerWedstrijd",
                table: "GebruikerWedstrijd",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerWedstrijd_GebruikerId",
                table: "GebruikerWedstrijd",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerWedstrijd_WedstrijdId",
                table: "GebruikerWedstrijd",
                column: "WedstrijdId");

            migrationBuilder.AddForeignKey(
                name: "FK_GebruikerWedstrijd_Gebruiker_GebruikerId",
                table: "GebruikerWedstrijd",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wedstrijd_Activiteit_ActiviteitId",
                table: "Wedstrijd",
                column: "ActiviteitId",
                principalTable: "Activiteit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GebruikerWedstrijd_Gebruiker_GebruikerId",
                table: "GebruikerWedstrijd");

            migrationBuilder.DropForeignKey(
                name: "FK_Wedstrijd_Activiteit_ActiviteitId",
                table: "Wedstrijd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GebruikerWedstrijd",
                table: "GebruikerWedstrijd");

            migrationBuilder.DropIndex(
                name: "IX_GebruikerWedstrijd_GebruikerId",
                table: "GebruikerWedstrijd");

            migrationBuilder.DropIndex(
                name: "IX_GebruikerWedstrijd_WedstrijdId",
                table: "GebruikerWedstrijd");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GebruikerWedstrijd");

            migrationBuilder.AlterColumn<int>(
                name: "ActiviteitId",
                table: "Wedstrijd",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "GebruikerWedstrijd",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GebruikerId1",
                table: "GebruikerWedstrijd",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GebruikerWedstrijd",
                table: "GebruikerWedstrijd",
                columns: new[] { "WedstrijdId", "GebruikerId" });

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerWedstrijd_GebruikerId1",
                table: "GebruikerWedstrijd",
                column: "GebruikerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GebruikerWedstrijd_Gebruiker_GebruikerId1",
                table: "GebruikerWedstrijd",
                column: "GebruikerId1",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wedstrijd_Activiteit_ActiviteitId",
                table: "Wedstrijd",
                column: "ActiviteitId",
                principalTable: "Activiteit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
