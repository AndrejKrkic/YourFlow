using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Account
    {
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }

        public void AddFunds(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.", nameof(amount));
            }
            Balance += amount;
        }

        public void RemoveFunds(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.", nameof(amount));
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
        }
    }
}
