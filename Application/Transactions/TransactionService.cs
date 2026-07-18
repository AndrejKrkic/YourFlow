using Application.Common.Interfaces;
using Application.Transactions.DTOs;
using Domain.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transactions
{
    internal class TransactionService : ITransactionService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(
            IAccountRepository accountRepository,
            ICategoryRepository categoryRepository,
            ITransactionRepository transactionRepository,
            IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ExecuteTransactionResult> ExecuteAsync(ExecuteTransactionRequest request, Guid userId, CancellationToken cancellationToken = default)
        {
            if (request.Amount <= 0)
            {
                throw new ArgumentException(
                    "Iznos transakcije mora biti veći od nule.");
            }

            var account = await _accountRepository.GetByIdAsync(
                request.AccountId,
                cancellationToken);

            if (account is null)
            {
                throw new KeyNotFoundException("Račun nije pronađen.");
            }

            //if (account != userId)
            //{
            //    throw new UnauthorizedAccessException(
            //        "Korisnik nema pristup ovom računu.");
            //}

            var category = await _categoryRepository.GetByIdAsync(
                request.CategoryId,
                cancellationToken);

            if (category is null)
            {
                throw new KeyNotFoundException("Kategorija nije pronađena.");
            }


            if (category.Type != request.Type)
            {
                throw new InvalidOperationException(
                    "Kategorija ne odgovara tipu transakcije.");
            }

            var transaction = new Transaction
            {
                CategoryId = request.CategoryId,
                Amount = request.Amount,
                Type = request.Type,
                TransactionDate = request.TransactionDate,
                Description = request.Description
            };

            switch (request.Type)
            {
                case TransactionType.Income:
                    account.AddFunds(request.Amount);
                    break;

                case TransactionType.Expense:
                    account.RemoveFunds(request.Amount);
                    break;

                default:
                    throw new InvalidOperationException(
                        "Nepodržan tip transakcije.");
            }

            await _transactionRepository.AddAsync(
                transaction,
                cancellationToken);

            _accountRepository.Update(account);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ExecuteTransactionResult(
                transaction.TransactionId,
                account.Balance);
        }
    }
}
