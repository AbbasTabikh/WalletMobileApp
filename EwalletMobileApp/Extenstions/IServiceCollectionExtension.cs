using EwalletMobileApp.Services;
using EwalletMobileApp.Services.Interfaces;
using EwalletMobileApp.Services.Repository;
using SQLite;

namespace EwalletMobileApp.Extenstions
{
    internal static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSqliteConnection(this IServiceCollection servicesDescriptor)
        {
            //Singleton for one user ( Scope = screen)
            servicesDescriptor.AddSingleton(provider =>
            {
                var asyncConnection = new SQLiteAsyncConnection(Constants.DataBasePath, Constants.Flags);
                return asyncConnection;
            });
            return servicesDescriptor;
        }
        public static IServiceCollection AddServices(this IServiceCollection servicesDescriptor)
        {
            //Singleton for one user ( Scope = screen)
            servicesDescriptor.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

            //Singleton for one user ( Scope = screen)
            servicesDescriptor.AddSingleton<IUnitOfWork, UnitOfWork>();
            servicesDescriptor.AddSingleton<IExpenseService, ExpenseService>();
            servicesDescriptor.AddSingleton<IBudgetService, BudgetService>();

            return servicesDescriptor;
        }
    }
}
