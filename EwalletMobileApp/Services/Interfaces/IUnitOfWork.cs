using EwalletMobileApp.MVVM.Models;
using EwalletMobileApp.Services.Repository;

namespace EwalletMobileApp.Services.Interfaces
{
    internal interface IUnitOfWork
    {
        Task ExecuteTransaction(Func<Task> transactionActions);
    }
}
