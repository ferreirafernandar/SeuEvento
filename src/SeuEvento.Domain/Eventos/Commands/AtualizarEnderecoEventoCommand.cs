using System;
using SeuEvento.Domain.Core.Commands;

namespace SeuEvento.Domain.Eventos.Commands
{
    public class AtualizarEnderecoEventoCommand : Command
    {
        public AtualizarEnderecoEventoCommand(Guid id,
                                              string logradouro,
                                              string numero,
                                              string complemento,
                                              string bairro,
                                              string cep,
                                              string cidade,
                                              string estado,
                                              Guid? eventoId)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            EventoId = eventoId;
        }

        public Guid Id { get; }
        public string Logradouro { get; }
        public string Numero { get; }
        public string Complemento { get; }
        public string Bairro { get; }
        public string Cep { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public Guid? EventoId { get; }
    }
}