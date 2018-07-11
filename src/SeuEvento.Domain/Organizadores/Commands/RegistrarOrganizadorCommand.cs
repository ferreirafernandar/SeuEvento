using System;
using SeuEvento.Domain.Eventos.Commands;

namespace SeuEvento.Domain.Organizadores.Commands
{
    public class RegistrarOrganizadorCommand : BaseEventoCommand
    {
        public RegistrarOrganizadorCommand(Guid id, string nome, string cpf, string email)
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