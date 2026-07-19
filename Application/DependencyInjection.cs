using Application.Accounts;
using Application.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}
