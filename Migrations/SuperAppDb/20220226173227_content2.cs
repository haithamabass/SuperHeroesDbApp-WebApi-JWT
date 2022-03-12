using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTSuperHeroesDb.Migrations.SuperAppDb
{
    public partial class content2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.RenameTable(
                name: "SuperHeroes",
                schema: "Super",
                newName: "SuperHeroes",
                newSchema: "Data");

            migrationBuilder.RenameTable(
                name: "Powers",
                schema: "Power",
                newName: "Powers",
                newSchema: "Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Power");

            migrationBuilder.EnsureSchema(
                name: "Super");

            migrationBuilder.RenameTable(
                name: "SuperHeroes",
                schema: "Data",
                newName: "SuperHeroes",
                newSchema: "Super");

            migrationBuilder.RenameTable(
                name: "Powers",
                schema: "Data",
                newName: "Powers",
                newSchema: "Power");
        }
    }
}
