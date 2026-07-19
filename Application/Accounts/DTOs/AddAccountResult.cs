using Domain.Enums;

namespace Application.Accounts.DTOs
{
    public sealed record AddAccountResult(
        Guid AccountId,
        string Name,
        Currency Currency,
        decimal Balance);
}
