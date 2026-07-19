using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<TransactionCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Categories
          .FirstOrDefaultAsync(
              x => x.Id == id,
              cancellationToken);
        }
    }
}
