﻿using System;
using SeuEvento.Domain.Core.Events;

namespace SeuEvento.Domain.Organizadores.Events
{
    public class OrganizadorRegistradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }

        public OrganizadorRegistradoEvent(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }
    }
}