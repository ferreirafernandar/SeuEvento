using SeuEvento.Domain.Organizadores;
using SeuEvento.Domain.Organizadores.Repository;
using SeuEvento.Infra.Data.Context;

namespace SeuEvento.Infra.Data.Repository
{
    public class OrganizadorRepository : Repository<Organizador>, IOrganizadorRepository
    {
        public OrganizadorRepository(EventosContext context) : base(context)
        {
        }
    }
}