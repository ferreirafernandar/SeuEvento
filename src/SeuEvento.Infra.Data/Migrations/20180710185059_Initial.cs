using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeuEvento.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                                         "Categorias",
                                         table => new
                                         {
                                             Id = table.Column<Guid>(nullable: false),
                                             varchar150 = table.Column<string>(name: "varchar(150)", nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_Categorias", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Organizadores",
                                         table => new
                                         {
                                             Id = table.Column<Guid>(nullable: false),
                                             varchar150 = table.Column<string>(name: "varchar(150)", nullable: false),
                                             varchar11 = table.Column<string>(name: "varchar(11)", maxLength: 11, nullable: false),
                                             varchar100 = table.Column<string>(name: "varchar(100)", nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_Organizadores", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Eventos",
                                         table => new
                                         {
                                             Id = table.Column<Guid>(nullable: false),
                                             Nome = table.Column<string>("varchar(150)", nullable: false),
                                             DescricaoCurta = table.Column<string>("varchar(150)", nullable: true),
                                             DescricaoLonga = table.Column<string>("varchar(max)", nullable: true),
                                             DataInicio = table.Column<DateTime>(nullable: false),
                                             DataFim = table.Column<DateTime>(nullable: false),
                                             Gratuito = table.Column<bool>(nullable: false),
                                             Valor = table.Column<decimal>(nullable: false),
                                             Online = table.Column<bool>(nullable: false),
                                             NomeEmpresa = table.Column<string>("varchar(150)", nullable: false),
                                             Ativo = table.Column<bool>(nullable: false),
                                             CategoriaId = table.Column<Guid>(nullable: true),
                                             EnderecoId = table.Column<Guid>(nullable: true),
                                             OrganizadorId = table.Column<Guid>(nullable: false)
                                         },
                                         constraints: table =>
                                                      {
                                                          table.PrimaryKey("PK_Eventos", x => x.Id);
                                                          table.ForeignKey(
                                                                           "FK_Eventos_Categorias_CategoriaId",
                                                                           x => x.CategoriaId,
                                                                           "Categorias",
                                                                           "Id",
                                                                           onDelete: ReferentialAction.Restrict);
                                                          table.ForeignKey(
                                                                           "FK_Eventos_Organizadores_OrganizadorId",
                                                                           x => x.OrganizadorId,
                                                                           "Organizadores",
                                                                           "Id",
                                                                           onDelete: ReferentialAction.Cascade);
                                                      });

            migrationBuilder.CreateTable(
                                         "Enderecos",
                                         table => new
                                         {
                                             Id = table.Column<Guid>(nullable: false),
                                             varchar150 = table.Column<string>(name: "varchar(150)", maxLength: 150, nullable: false),
                                             varchar20 = table.Column<string>(name: "varchar(20)", maxLength: 20, nullable: false),
                                             Complemento = table.Column<string>(nullable: true),
                                             varchar50 = table.Column<string>(name: "varchar(50)", maxLength: 50, nullable: false),
                                             varchar8 = table.Column<string>(name: "varchar(8)", maxLength: 8, nullable: false),
                                             Cidade = table.Column<string>(nullable: true),
                                             Estado = table.Column<string>(nullable: true),
                                             EventoId = table.Column<Guid>(nullable: true)
                                         },
                                         constraints: table =>
                                                      {
                                                          table.PrimaryKey("PK_Enderecos", x => x.Id);
                                                          table.ForeignKey(
                                                                           "FK_Enderecos_Eventos_EventoId",
                                                                           x => x.EventoId,
                                                                           "Eventos",
                                                                           "Id",
                                                                           onDelete: ReferentialAction.Restrict);
                                                      });

            migrationBuilder.CreateIndex(
                                         "IX_Enderecos_EventoId",
                                         "Enderecos",
                                         "EventoId",
                                         unique: true,
                                         filter: "[EventoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                                         "IX_Eventos_CategoriaId",
                                         "Eventos",
                                         "CategoriaId");

            migrationBuilder.CreateIndex(
                                         "IX_Eventos_OrganizadorId",
                                         "Eventos",
                                         "OrganizadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                                       "Enderecos");

            migrationBuilder.DropTable(
                                       "Eventos");

            migrationBuilder.DropTable(
                                       "Categorias");

            migrationBuilder.DropTable(
                                       "Organizadores");
        }
    }
}