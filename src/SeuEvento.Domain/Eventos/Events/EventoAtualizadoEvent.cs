using System;

namespace SeuEvento.Domain.Eventos.Events
{
    public class EventoAtualizadoEvent : BaseEventoEvent
    {
        public EventoAtualizadoEvent(
            Guid id,
            string nome,
            string descricaoCurta,
            string descricaoLonga,
            DateTime dataInicio,
            DateTime dataFim,
            bool gratuito,
            decimal valor,
            bool online,
            string nomeEmpresa)
        {
            Id = id;
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Online = online;
            Gratuito = gratuito;
            Valor = valor;
            NomeEmpresa = nomeEmpresa;

            AggregateId = id;
        }
    }
}