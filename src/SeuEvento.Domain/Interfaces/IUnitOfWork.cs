using System;
using SeuEvento.Domain.Core.Commands;

namespace SeuEvento.Domain.Eventos.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}