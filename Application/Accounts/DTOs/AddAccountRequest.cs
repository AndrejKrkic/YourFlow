using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.Accounts.DTOs
{
    public sealed class AddAccountRequest
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; init; }

        [EnumDataType(typeof(Currency))]
        public required Currency Currency { get; init; }
    }
}
