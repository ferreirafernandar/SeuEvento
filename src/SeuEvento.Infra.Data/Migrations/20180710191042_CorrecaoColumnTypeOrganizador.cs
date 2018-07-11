using Microsoft.EntityFrameworkCore.Migrations;

namespace SeuEvento.Infra.Data.Migrations
{
    public partial class CorrecaoColumnTypeOrganizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                                          "varchar(150)",
                                          "Organizadores",
                                          "Nome");

            migrationBuilder.RenameColumn(
                                          "varchar(100)",
                                          "Organizadores",
                                          "Email");

            migrationBuilder.RenameColumn(
                                          "varchar(11)",
                                          "Organizadores",
                                          "Cpf");

            migrationBuilder.AlterColumn<string>(
                                                 "Nome",
                                                 "Organizadores",
                                                 "varchar(150)",
                                                 nullable: false,
                                                 oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                                                 "Email",
                                                 "Organizadores",
                                                 "varchar(100)",
                                                 nullable: false,
                                                 oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                                                 "Cpf",
                                                 "Organizadores",
                                                 "varchar(11)",
                                                 maxLength: 11,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                                          "Nome",
                                          "Organizadores",
                                          "varchar(150)");

            migrationBuilder.RenameColumn(
                                          "Email",
                                          "Organizadores",
                                          "varchar(100)");

            migrationBuilder.RenameColumn(
                                          "Cpf",
                                          "Organizadores",
                                          "varchar(11)");

            migrationBuilder.AlterColumn<string>(
                                                 "varchar(150)",
                                                 "Organizadores",
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                                                 "varchar(100)",
                                                 "Organizadores",
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                                                 "varchar(11)",
                                                 "Organizadores",
                                                 maxLength: 11,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(11)",
                                                 oldMaxLength: 11);
        }
    }
}