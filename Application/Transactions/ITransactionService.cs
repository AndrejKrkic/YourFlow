using Application.Transactions.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transactions
{
    public interface ITransactionService
    {
        Task<ExecuteTransactionResult> ExecuteAsync(
        ExecuteTransactionRequest request,
        Guid userId,
        CancellationToken cancellationToken = default);
    }
}
