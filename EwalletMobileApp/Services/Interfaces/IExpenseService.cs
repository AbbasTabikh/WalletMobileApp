using EwalletMobileApp.MVVM.Models;

namespace EwalletMobileApp.Services.Interfaces
{
    internal interface IExpenseService
    {
        Task<Expense?> GetByID(int id, CancellationToken cancellationToken);
        Task Create(Expense entity);
        Task<Expense?> Update(Expense entity, CancellationToken cancellationToken);
        Task Delete(int id);
        Task DeleteAll(IEnumerable<int> ids);
    }
}
