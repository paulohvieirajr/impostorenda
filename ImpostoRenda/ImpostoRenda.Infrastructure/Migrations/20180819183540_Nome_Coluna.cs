using Microsoft.EntityFrameworkCore.Migrations;

namespace ImpostoRenda.Infrastructure.Migrations
{
    public partial class Nome_Coluna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contribuinte");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Contribuinte",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Contribuinte",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "SalarioComDesconto",
                table: "Contribuinte",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Contribuinte");

            migrationBuilder.DropColumn(
                name: "SalarioComDesconto",
                table: "Contribuinte");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Contribuinte",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contribuinte",
                nullable: false,
                defaultValue: "");
        }
    }
}
