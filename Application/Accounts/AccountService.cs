using Application.Accounts.DTOs;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Accounts
{
    internal sealed class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddAccountResult> AddAsync(
            AddAccountRequest request,
            CancellationToken cancellationToken = default)
        {
            var account = new Account(
                Guid.Empty,
                request.Name,
                request.Currency);

            await _accountRepository.AddAsync(account, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new AddAccountResult(
                account.AccountId,
                account.Name,
                account.Currency,
                account.Balance);
        }
    }
}
