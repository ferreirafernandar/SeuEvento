﻿using SeuEvento.Domain.Core.Commands;
using SeuEvento.Domain.Interfaces;
using SeuEvento.Infra.Data.Context;

namespace SeuEvento.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventosContext _context;

        public UnitOfWork(EventosContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}