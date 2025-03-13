using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace PrjApiLembrete.Migrations
{
    /// <inheritdoc />
    public partial class CriaCaoTabelaLembrete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lembretes",
                columns: table => new
                {
                    LembreteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TituloLembrete = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CorpoLembrete = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    StatusLembrete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lembretes", x => x.LembreteId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lembretes");
        }
    }
}
