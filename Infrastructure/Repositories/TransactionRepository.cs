using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
