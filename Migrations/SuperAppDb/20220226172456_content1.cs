using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTSuperHeroesDb.Migrations.SuperAppDb
{
    public partial class content1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Power");

            migrationBuilder.EnsureSchema(
                name: "Super");

            migrationBuilder.CreateTable(
                name: "Powers",
                schema: "Power",
                columns: table => new
                {
                    PowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.PowerId);
                });

            migrationBuilder.CreateTable(
                name: "SuperHeroes",
                schema: "Super",
                columns: table => new
                {
                    SuperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    PowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroes", x => x.SuperId);
                    table.ForeignKey(
                        name: "FK_SuperHeroes_Powers_PowerId",
                        column: x => x.PowerId,
                        principalSchema: "Power",
                        principalTable: "Powers",
                        principalColumn: "PowerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_PowerId",
                schema: "Super",
                table: "SuperHeroes",
                column: "PowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroes",
                schema: "Super");

            migrationBuilder.DropTable(
                name: "Powers",
                schema: "Power");
        }
    }
}
