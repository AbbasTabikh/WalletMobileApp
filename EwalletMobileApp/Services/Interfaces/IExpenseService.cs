using EwalletMobileApp.MVVM.Models;

namespace EwalletMobileApp.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<Expense?> GetByID(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Expense>?> GetAll(int budgetID, CancellationToken cancellationToken);
        Task Create(Expense entity);
        Task<Expense?> Update(Expense entity, CancellationToken cancellationToken);
        Task Delete(int id);
        Task DeleteAll(IEnumerable<int> ids);
    }
}
