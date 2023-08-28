using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClimaAec.Migrations
{
    /// <inheritdoc />
    public partial class Logs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Metodo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rota = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
