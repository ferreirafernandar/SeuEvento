using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SeuEvento.Domain.Eventos;
using SeuEvento.Domain.Eventos.Repository;

namespace ConsoleTest
{
    public class FakeEventoRepository : IEventoRepository
    {
        private readonly IEventoRepository _eventoRepository;

        public FakeEventoRepository(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public FakeEventoRepository()
        {
        }

        public void Adicionar(Evento obj)
        {
            _eventoRepository.Adicionar(obj);
        }

        public Evento ObterPorId(Guid id)
        {
            return new Evento("Fake", DateTime.Now, DateTime.Now, true, 0, true, "Empresa");
        }
        public void Dispose()
        {
            _eventoRepository.Dispose();
        }
        public IEnumerable<Evento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Evento obj)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> Buscar(Expression<Func<Evento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            throw new NotImplementedException();
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}