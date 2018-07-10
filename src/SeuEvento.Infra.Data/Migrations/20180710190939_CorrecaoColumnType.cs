using Microsoft.EntityFrameworkCore.Migrations;

namespace SeuEvento.Infra.Data.Migrations
{
    public partial class CorrecaoColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(20)",
                table: "Enderecos",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "varchar(150)",
                table: "Enderecos",
                newName: "Logradouro");

            migrationBuilder.RenameColumn(
                name: "varchar(8)",
                table: "Enderecos",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "varchar(50)",
                table: "Enderecos",
                newName: "Bairro");

            migrationBuilder.RenameColumn(
                name: "varchar(150)",
                table: "Categorias",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Enderecos",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Enderecos",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Enderecos",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Enderecos",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Enderecos",
                newName: "varchar(20)");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "Enderecos",
                newName: "varchar(150)");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Enderecos",
                newName: "varchar(8)");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Enderecos",
                newName: "varchar(50)");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Categorias",
                newName: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(20)",
                table: "Enderecos",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "varchar(150)",
                table: "Enderecos",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "varchar(8)",
                table: "Enderecos",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "varchar(50)",
                table: "Enderecos",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "varchar(150)",
                table: "Categorias",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");
        }
    }
}
