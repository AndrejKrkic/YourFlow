using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    internal interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(
       CancellationToken cancellationToken = default);
    }
}
