using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
