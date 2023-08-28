using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClimaAec.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeroportos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Vento = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Temperatura = table.Column<decimal>(type: "decimal(18,2)", maxLength: 5, nullable: false),
                    Condicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroportos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TemperaturaMinima = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    TemperaturaMaxima = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Condicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AtualizadoEm = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeroportos");

            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
