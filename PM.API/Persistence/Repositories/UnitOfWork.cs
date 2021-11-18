using PM.API.Domain.Entities;
using PM.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PMContext _context;
        public UnitOfWork(PMContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}