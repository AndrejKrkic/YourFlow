using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transactions.DTOs
{
    public sealed record ExecuteTransactionResult
    {
        Guid TransactionID  { get; set; }
        decimal NewAccountBalance { get; set; }
    }
}
