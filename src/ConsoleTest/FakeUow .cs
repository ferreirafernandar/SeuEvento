using System;
using SeuEvento.Domain.Core.Commands;
using SeuEvento.Domain.Interfaces;

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