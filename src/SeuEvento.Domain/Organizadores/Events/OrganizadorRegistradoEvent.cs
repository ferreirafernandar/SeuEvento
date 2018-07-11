using System;
using SeuEvento.Domain.Core.Events;

namespace SeuEvento.Domain.Organizadores.Events
{
    public class OrganizadorRegistradoEvent : Event
    {
        public OrganizadorRegistradoEvent(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }

        public Guid Id { get; }
        public string Nome { get; }
        public string Cpf { get; }
        public string Email { get; }
    }
}