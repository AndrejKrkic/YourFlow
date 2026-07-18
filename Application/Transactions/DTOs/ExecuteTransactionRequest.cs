using Domain.Enums;

namespace Application.Transactions.DTOs
{
    public sealed record ExecuteTransactionRequest(
    Guid AccountId,
    Guid CategoryId,
    decimal Amount,
    TransactionType Type,
    DateTime TransactionDate,
    string? Description);
}
