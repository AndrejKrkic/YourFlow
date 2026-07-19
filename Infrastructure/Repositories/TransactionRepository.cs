using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            await _dbContext.Transactions.AddAsync(transaction, cancellationToken);
        }

        public Task<Transaction?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
        {
            return _dbContext.Transactions
                .FirstOrDefaultAsync(
                    x => x.CategoryId == id,
                    cancellationToken);
        }
    }
}
