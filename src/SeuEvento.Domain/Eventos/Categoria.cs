using System;
using System.Collections.Generic;
using SeuEvento.Domain.Core.Models;

namespace SeuEvento.Domain.Eventos
{
    public class Categoria : Entity<Categoria>
    {
        public Categoria(Guid id) => Id = id;

        protected Categoria()
        {
        }

        public string Nome { get; private set; }

        public virtual ICollection<Evento> Eventos { get; set; }

        public override bool EhValido() => true;
    }
}