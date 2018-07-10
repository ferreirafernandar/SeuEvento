using SeuEvento.Domain.CommandHandlers;
using SeuEvento.Domain.Core.Bus;
using SeuEvento.Domain.Core.Events;
using SeuEvento.Domain.Core.Notifications;
using SeuEvento.Domain.Interfaces;
using SeuEvento.Domain.Organizadores.Events;
using SeuEvento.Domain.Organizadores.Repository;
using System.Linq;

namespace SeuEvento.Domain.Organizadores.Commands
{
    public class OrganizadorCommandHandler : CommandHandler,
                                             IHandler<RegistrarOrganizadorCommand>
    {
        private readonly IBus _bus;
        private readonly IOrganizadorRepository _organizadorRepository;

        public OrganizadorCommandHandler(
            IUnitOfWork uow,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IOrganizadorRepository organizadorRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _organizadorRepository = organizadorRepository;
        }

        public void Handle(RegistrarOrganizadorCommand message)
        {
            var organizador = new Organizador(message.Id);

            if (!organizador.EhValido())
            {
                NotificarValicacoesErro(organizador.ValidationResult);
                return;
            }

            var organizadorExistente = _organizadorRepository.Buscar(o => o.Cpf == organizador.Cpf || o.Email == organizador.Email);

            if (organizadorExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou e-mail já utilizados"));
            }

            _organizadorRepository.Adicionar(organizador);

            if (Commit())
            {
                _bus.RaiseEvent(new OrganizadorRegistradoEvent(organizador.Id, organizador.Nome, organizador.Cpf, organizador.Email));
            }
        }
    }
}