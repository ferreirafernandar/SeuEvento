﻿using System;
using SeuEvento.Domain.CommandHandlers;
using SeuEvento.Domain.Core.Bus;
using SeuEvento.Domain.Core.Events;
using SeuEvento.Domain.Core.Notifications;
using SeuEvento.Domain.Eventos.Events;
using SeuEvento.Domain.Eventos.Repository;
using SeuEvento.Domain.Interfaces;

namespace SeuEvento.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
                                        IHandler<RegistrarEventoCommand>,
                                        IHandler<AtualizarEventoCommand>,
                                        IHandler<ExcluirEventoCommand>,
                                        IHandler<IncluirEnderecoEventoCommand>,
                                        IHandler<AtualizarEnderecoEventoCommand>

    {
        private readonly IBus _bus;
        private readonly IEventoRepository _eventoRepository;
        private readonly IUser _user;

        public EventoCommandHandler(IEventoRepository eventoRepository, IUnitOfWork uow, IBus bus, IUser user, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _eventoRepository = eventoRepository;
            _bus = bus;
            _user = user;
        }

        public void Handle(AtualizarEventoCommand message)
        {
            var eventoAtual = _eventoRepository.ObterPorId(message.Id);

            if (!EventoExistente(message.Id, message.MessageType)) return;

            if (eventoAtual.OrganizadorId != _user.GetUserId())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Evento não pertencente ao Organizador"));
                return;
            }

            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id, message.Nome, message.DescricaoCurta,
                                                                 message.DescricaoLonga, message.DataInicio, message.DataFim, message.Gratuito, message.Valor,
                                                                 message.Online, message.NomeEmpresa, message.OrganizadorId, eventoAtual.Endereco, message.CategoriaId);

            if (!evento.Online && evento.Endereco == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possivel atualizar um evento sem informar o endereço"));
                return;
            }

            if (!EventoValido(evento)) return;

            _eventoRepository.Atualizar(evento);

            if (Commit())
                _bus.RaiseEvent(new EventoAtualizadoEvent(evento.Id, evento.Nome, evento.DescricaoCurta, evento.DescricaoLonga, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
        }

        public void Handle(ExcluirEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;
            var eventoAtual = _eventoRepository.ObterPorId(message.Id);

            if (eventoAtual.OrganizadorId != _user.GetUserId())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Evento não pertencente ao Organizador"));
                return;
            }

            // Validacoes de negocio
            eventoAtual.ExcluirEvento();

            _eventoRepository.Atualizar(eventoAtual);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoExcluidoEvent(message.Id));
            }
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var endereco = new Endereco(message.Endereco.Id, message.Endereco.Logradouro, message.Endereco.Numero, message.Endereco.Complemento, message.Endereco.Bairro, message.Endereco.Cep, message.Endereco.Cidade, message.Endereco.Estado, message.Endereco.EventoId.GetValueOrDefault());

            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id, message.Nome, message.DescricaoCurta,
                                                                 message.DescricaoLonga, message.DataInicio, message.DataFim, message.Gratuito, message.Valor,
                                                                 message.Online, message.NomeEmpresa, message.OrganizadorId, endereco, message.CategoriaId);

            if (!EventoValido(evento)) return;

            _eventoRepository.Adicionar(evento);

            if (!Commit()) return;

            _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
        }

        private bool EventoValido(Evento evento)
        {
            if (evento.EhValido()) return true;

            NotificarValidacoesErro(evento.ValidationResult);
            return false;
        }

        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _eventoRepository.ObterPorId(id);

            if (evento != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrado."));

            return false;
        }

        #region Endereço

        public void Handle(IncluirEnderecoEventoCommand message)
        {
            var endereco = new Endereco(message.Id, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.Cep, message.Cidade, message.Estado, message.EventoId.GetValueOrDefault());
            if (!endereco.EhValido())
            {
                NotificarValidacoesErro(endereco.ValidationResult);
                return;
            }

            _eventoRepository.AdicionarEndereco(endereco);

            if (Commit())
            {
                _bus.RaiseEvent(new EnderecoEventoAdicionadoEvent(endereco.Id, endereco.Logradouro, endereco.Numero, endereco.Complemento, endereco.Bairro, endereco.Cep, endereco.Cidade, endereco.Estado, endereco.EventoId.Value));
            }
        }

        public void Handle(AtualizarEnderecoEventoCommand message)
        {
            var endereco = new Endereco(message.Id, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.Cep, message.Cidade, message.Estado, message.EventoId.GetValueOrDefault());
            if (!endereco.EhValido())
            {
                NotificarValidacoesErro(endereco.ValidationResult);
                return;
            }

            _eventoRepository.AtualizarEndereco(endereco);

            if (Commit())
            {
                _bus.RaiseEvent(new EnderecoEventoAtualizadoEvent(endereco.Id, endereco.Logradouro, endereco.Numero, endereco.Complemento, endereco.Bairro, endereco.Cep, endereco.Cidade, endereco.Estado, endereco.EventoId.Value));
            }
        }

        #endregion
    }
}