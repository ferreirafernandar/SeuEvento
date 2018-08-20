using System;
using System.Collections.Generic;
using SeuEvento.Domain.Core.Models;
using SeuEvento.Domain.Eventos;

namespace SeuEvento.Domain.Organizadores
{
    public class Organizador : Entity<Organizador>
    {
        public Organizador(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }

        // EF Construtor
        protected Organizador()
        {
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }

        // EF Propriedade de Navegação
        public virtual ICollection<Evento> Eventos { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}