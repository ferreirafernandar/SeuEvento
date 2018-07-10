using System;
using SeuEvento.Domain.Core.Commands;

namespace SeuEvento.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}