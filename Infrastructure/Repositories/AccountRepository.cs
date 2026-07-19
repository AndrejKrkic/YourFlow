using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Accounts
           .FirstOrDefaultAsync(
               x => x.AccountId == id,
               cancellationToken);
        }

        public async Task AddAsync(Account account, CancellationToken cancellationToken = default)
        {
            await _dbContext.Accounts.AddAsync(account, cancellationToken);
        }

        public void Update(Account account)
        {
            _dbContext.Accounts.Update(account);
        }

    }
}
