using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Update(Account account);
    }
}
