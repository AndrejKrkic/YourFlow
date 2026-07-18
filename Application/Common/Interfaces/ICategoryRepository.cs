using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    internal interface ICategoryRepository
    {
        Task<TransactionCategory?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
    }
}
