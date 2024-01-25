using EwalletMobileApp.Models;
using EwalletMobileApp.MVVM.Models;
using EwalletMobileApp.Services.Interfaces;
using EwalletMobileApp.Services.Repository;

namespace EwalletMobileApp.Services
{
    public class BudgetService : BaseService<Budget>, IBudgetService
    {
        private readonly IRepository<Budget> _budgetRepository;
        public BudgetService(IRepository<Budget> budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<IEnumerable<Budget>> Get(QueryParameters queryParameters, CancellationToken cancellationToken)
        {
            var query = _budgetRepository.GetAsTableQuery(null);
            var requestedItems = await GetRequestedItems(query, queryParameters.CurrentPage, queryParameters.PageSize);
            return requestedItems;
        }
        public async Task<Budget?> GetByID(int id, CancellationToken cancellationToken)
        {
            return await _budgetRepository.GetByID(id, true, cancellationToken);
        }
        public async Task DeleteAll(IEnumerable<int> ids)
        {
            await _budgetRepository.BulkDelete(ids);
        }
        public async Task Create(Budget entity)
        {
            bool hasExpenses = entity.Expenses is not null && entity.Expenses.Count is not 0;
            await _budgetRepository.Create(entity, hasExpenses);
        }
        public async Task Delete(int id)
        {
            await _budgetRepository.Delete(id);
        }
        public async Task<Budget?> Update(Budget entity, CancellationToken cancellationToken)
        {
            return await _budgetRepository.Update(entity, cancellationToken);
        }

        public async Task<bool> UpdateTotal(int id, decimal originalExpensePrice, decimal newExpensePrice, CancellationToken cancellation)
        {
            string query = $@"UPDATE Expenses
                            SET Total = (Total + {originalExpensePrice}) - {newExpensePrice}
                            WHERE BudgetId = {id}";

            return await _budgetRepository.ExecuteQuery(query, cancellation);
        }
    }
}
