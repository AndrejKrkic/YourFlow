using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TransactionCategory
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public TransactionType Type { get; set; }

        public string UserId { get; set; } = null!;
    }
}
