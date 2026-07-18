using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
        public TransactionCategory Category { get; set; } = null!;

        public string UserId { get; set; } = null!;
    }
}
