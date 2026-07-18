using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    internal interface ITransactionRepository
    {
        Task AddAsync(
        Transaction transaction,
        CancellationToken cancellationToken = default);
    }
}
