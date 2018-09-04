using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using SeuEvento.Domain.Eventos;
using SeuEvento.Domain.Eventos.Repository;
using SeuEvento.Infra.Data.Context;

namespace SeuEvento.Infra.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(EventosContext context) : base(context)
        {
        }

        public override IEnumerable<Evento> ObterTodos()
        {
            const string sql = @"SELECT *
                                 FROM Eventos E
                                 WHERE E.Excluido = 0
                                 ORDER BY E.DataFim DESC";

            return Db.Database.GetDbConnection().Query<Evento>(sql);
        }

        public override Evento ObterPorId(Guid id)
        {
            const string sql = @"SELECT *
                                 FROM Eventos E
                                     LEFT JOIN Enderecos EN
                                         ON E.Id = EN.EventoId
                                 WHERE E.Id = @uid";

            var evento = Db.Database.GetDbConnection().Query<Evento, Endereco, Evento>(sql,
                (e, en) =>
                {
                    if (en != null)
                        e.AtribuirEndereco(en);

                    return e;
                }, new { uid = id });

            return evento.FirstOrDefault();
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            const string sql = @"SELECT *
                                 FROM Eventos E
                                 WHERE E.Excluido = 0
                                       AND E.OrganizadorId = @oid
                                 ORDER BY E.DataFim DESC";

            //throw new Exception("Ocorreu um erro");
            return Db.Database.GetDbConnection().Query<Evento>(sql, new { oid = organizadorId });
        }

        public override void Remover(Guid id)
        {
            var evento = ObterPorId(id);
            evento.ExcluirEvento();
            Atualizar(evento);
        }

        #region Endereço

        public Endereco ObterEnderecoPorId(Guid id)
        {
            const string sql = @"SELECT *
                                 FROM Enderecos E
                                 WHERE E.Id = @uid";

            var endereco = Db.Database.GetDbConnection().Query<Endereco>(sql, new { uid = id });

            return endereco.SingleOrDefault();
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }

        #endregion
    }
}