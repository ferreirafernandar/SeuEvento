using System;

namespace SeuEvento.Domain.Eventos.Events
{
    public class EventoRegistradoEvent : BaseEventoEvent
    {
        public EventoRegistradoEvent(
            Guid id,
            string nome,
            DateTime dataInicio,
            DateTime dataFim,
            bool gratuito,
            decimal valor,
            bool online,
            string nomeEmpresa)
        {
            Id = id;
            Nome = nome;
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