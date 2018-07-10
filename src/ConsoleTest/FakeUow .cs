using SeuEvento.Domain.Core.Commands;
using SeuEvento.Domain.Interfaces;
using System;

namespace ConsoleTest
{
    public class FakeUow : IUnitOfWork
    {
        public CommandResponse Commit()
        {
            return new CommandResponse(true);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}