using Microsoft.EntityFrameworkCore.Migrations;

namespace SeuEvento.Infra.Data.Migrations
{
    public partial class CorrecaoColumnTypeBairro2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                                                 "Bairro",
                                                 "Enderecos",
                                                 "varchar(50)",
                                                 maxLength: 50,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(51)",
                                                 oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                                                 "Bairro",
                                                 "Enderecos",
                                                 "varchar(51)",
                                                 maxLength: 50,
                                                 nullable: false,
                                                 oldClrType: typeof(string),
                                                 oldType: "varchar(50)",
                                                 oldMaxLength: 50);
        }
    }
}