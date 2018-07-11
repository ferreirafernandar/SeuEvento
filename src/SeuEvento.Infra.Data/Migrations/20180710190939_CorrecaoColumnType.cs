using Microsoft.EntityFrameworkCore.Migrations;

namespace SeuEvento.Infra.Data.Migrations
{
    public partial class CorrecaoColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                                          "varchar(20)",
                                          "Enderecos",
                                          "Numero");

            migrationBuilder.RenameColumn(
                                          "varchar(150)",
                                          "Enderecos",
                                          "Logradouro");

            migrationBuilder.RenameColumn(
                                          "varchar(8)",
                                          "Enderecos",
                                          "Cep");

            migrationBuilder.RenameColumn(
                                          "varchar(50)",
                                          "Enderecos",
                                          "Bairro");

            migrationBuilder.RenameColumn(
                                          "varchar(150)",
                                          "Categorias",
                                          "Nome");

            migrationBuilder.AlterColumn<string>(
                                                 "Numero",
                                                 "Enderecos",
                                                 "varchar(20)",
                                                 maxLength: 20,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                                                 "Logradouro",
                                                 "Enderecos",
                                                 "varchar(150)",
                                                 maxLength: 150,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                                                 "Cep",
                                                 "Enderecos",
                                                 "varchar(8)",
                                                 maxLength: 8,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                                                 "Bairro",
                                                 "Enderecos",
                                                 "varchar(50)",
                                                 maxLength: 50,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                                                 "Nome",
                                                 "Categorias",
                                                 "varchar(150)",
                                                 nullable: false,
                                                 oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                                          "Numero",
                                          "Enderecos",
                                          "varchar(20)");

            migrationBuilder.RenameColumn(
                                          "Logradouro",
                                          "Enderecos",
                                          "varchar(150)");

            migrationBuilder.RenameColumn(
                                          "Cep",
                                          "Enderecos",
                                          "varchar(8)");

            migrationBuilder.RenameColumn(
                                          "Bairro",
                                          "Enderecos",
                                          "varchar(50)");

            migrationBuilder.RenameColumn(
                                          "Nome",
                                          "Categorias",
                                          "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                                                 "varchar(20)",
                                                 "Enderecos",
                                                 maxLength: 20,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(20)",
                                                 oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                                                 "varchar(150)",
                                                 "Enderecos",
                                                 maxLength: 150,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(150)",
                                                 oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                                                 "varchar(8)",
                                                 "Enderecos",
                                                 maxLength: 8,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(8)",
                                                 oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                                                 "varchar(50)",
                                                 "Enderecos",
                                                 maxLength: 50,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(50)",
                                                 oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                                                 "varchar(150)",
                                                 "Categorias",
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(150)");
        }
    }
}