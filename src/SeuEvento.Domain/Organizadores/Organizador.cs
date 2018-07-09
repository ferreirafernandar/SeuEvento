using System;
using System.Collections.Generic;
using SeuEvento.Domain.Core.Models;
using SeuEvento.Domain.Eventos;

namespace SeuEvento.Domain.Organizadores
{
    public class Organizador : Entity<Organizador>
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }

        public Organizador(Guid id)
        {
            Id = id;
         
        }

        // EF Construtor
        protected Organizador() { }

        // EF Propriedade de Navegação
        public virtual ICollection<Evento> Eventos { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}