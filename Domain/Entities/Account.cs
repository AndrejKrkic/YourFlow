using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Account
    {
        private Account()
        {
            Name = string.Empty;
        }

        public Account(Guid userId, string name, Currency currency)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Account name is required.", nameof(name));
            }

            if (!Enum.IsDefined(currency))
            {
                throw new ArgumentOutOfRangeException(nameof(currency), "Unsupported currency.");
            }

            AccountId = Guid.NewGuid();
            UserId = userId;
            Name = name.Trim();
            Currency = currency;
            Balance = 0;
        }

        public Guid AccountId { get; set; }
        public Guid UserId { get; private set; }
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
        public string Name { get; set; }

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
