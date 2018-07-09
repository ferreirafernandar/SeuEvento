using SeuEvento.Domain.Core.Events;

namespace SeuEvento.Domain.Organizadores.Events
{
    public class OrganizadorEventHandler :
        IHandler<OrganizadorRegistradoEvent>
    {
        public void Handle(OrganizadorRegistradoEvent message)
        {
            // TODO: Enviar um email?
        }
    }
}