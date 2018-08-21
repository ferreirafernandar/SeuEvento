﻿using System;
using SeuEvento.Domain.Core.Events;

namespace SeuEvento.Domain.Eventos.Events
{
    public class EnderecoEventoAdicionadoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public EnderecoEventoAdicionadoEvent(Guid enderecoId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, Guid eventoId)
        {
            Id = enderecoId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            AggregateId = eventoId;
        }
    }
}