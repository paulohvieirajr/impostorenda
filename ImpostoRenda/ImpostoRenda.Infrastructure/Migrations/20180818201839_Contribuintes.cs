using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImpostoRenda.Infrastructure.Migrations
{
    public partial class Contribuintes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contribuinte",
                columns: table => new
                {
                    IdContribuinte = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Dependentes = table.Column<int>(nullable: false),
                    Salario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuinte", x => x.IdContribuinte);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contribuinte");
        }
    }
}
