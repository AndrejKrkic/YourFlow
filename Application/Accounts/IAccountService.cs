using Application.Accounts.DTOs;

namespace Application.Accounts
{
    public interface IAccountService
    {
        Task<AddAccountResult> AddAsync(
            AddAccountRequest request,
            CancellationToken cancellationToken = default);
    }
}
