using EwalletMobileApp.Services.Interfaces;
using SQLite;

namespace EwalletMobileApp.Services
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SQLiteAsyncConnection _asyncConnection;
        public UnitOfWork(SQLiteAsyncConnection asyncConnection)
        {
            _asyncConnection = asyncConnection;
        }
        public async Task ExecuteTransaction(Func<Task> transactionActions)
        {
            await _asyncConnection.RunInTransactionAsync(async conn =>
            {
                await transactionActions();
            });
        }
    }
}
