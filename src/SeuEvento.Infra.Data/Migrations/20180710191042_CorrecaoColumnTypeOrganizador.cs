using Microsoft.EntityFrameworkCore.Migrations;

namespace SeuEvento.Infra.Data.Migrations
{
    public partial class CorrecaoColumnTypeOrganizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(150)",
                table: "Organizadores",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "varchar(100)",
                table: "Organizadores",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "varchar(11)",
                table: "Organizadores",
                newName: "Cpf");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Organizadores",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Organizadores",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Organizadores",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Organizadores",
                newName: "varchar(150)");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Organizadores",
                newName: "varchar(100)");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Organizadores",
                newName: "varchar(11)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(150)",
                table: "Organizadores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(100)",
                table: "Organizadores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(11)",
                table: "Organizadores",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);
        }
    }
}
