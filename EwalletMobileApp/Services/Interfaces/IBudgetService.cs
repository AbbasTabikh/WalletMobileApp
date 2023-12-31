using EwalletMobileApp.Models;
using EwalletMobileApp.MVVM.Models;

namespace EwalletMobileApp.Services.Interfaces
{
    internal interface IBudgetService
    {
        Task<IEnumerable<Budget>> GetItems(QueryParameters queryParameters, CancellationToken cancellationToken);
        Task<Budget?> GetByID(int id, CancellationToken cancellationToken);
        Task Create(Budget entity);
        Task<Budget?> Update(Budget entity, CancellationToken cancellationToken);
        Task<bool> UpdateTotal(int id,decimal originalExpensePrice, decimal newExpensePrice, CancellationToken cancellationToken); 
        Task Delete(int id);
        Task DeleteAll(IEnumerable<int> ids);
    }
}
