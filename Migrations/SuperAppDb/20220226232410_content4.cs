using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTSuperHeroesDb.Migrations.SuperAppDb
{
    public partial class content4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                schema: "Data",
                table: "SuperHeroes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                schema: "Data",
                table: "SuperHeroes");
        }
    }
}
