using EwalletMobileApp.Models;
using EwalletMobileApp.MVVM.Models;

namespace EwalletMobileApp.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<IEnumerable<Budget>> Get(QueryParameters queryParameters, CancellationToken cancellationToken);
        Task<Budget?> GetByID(int id, CancellationToken cancellationToken);
        Task Create(Budget entity);
        Task<Budget?> Update(Budget entity, CancellationToken cancellationToken);
        Task<bool> UpdateTotal(int id, decimal originalExpensePrice, decimal newExpensePrice, CancellationToken cancellationToken);
        Task Delete(Budget budget);
        Task DeleteAll(IEnumerable<int> ids);
    }
}
