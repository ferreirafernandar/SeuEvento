using AutoMapper;
using SeuEvento.Application.Interfaces;
using SeuEvento.Application.ViewModels;
using SeuEvento.Domain.Core.Bus;
using SeuEvento.Domain.Organizadores.Commands;
using SeuEvento.Domain.Organizadores.Repository;

namespace SeuEvento.Application.Services
{
    public class OrganizadorAppService : IOrganizadorAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IOrganizadorRepository _organizadorRepository;

        public OrganizadorAppService(IMapper mapper, IOrganizadorRepository organizadorRepository, IBus bus)
        {
            _mapper = mapper;
            _organizadorRepository = organizadorRepository;
            _bus = bus;
        }

        public void Registrar(OrganizadorViewModel organizadorViewModel)
        {
            var registroCommand = _mapper.Map<RegistrarOrganizadorCommand>(organizadorViewModel);
            _bus.SendCommand(registroCommand);
        }

        public void Dispose()
        {
            _organizadorRepository.Dispose();
        }
    }
}