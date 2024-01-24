using EwalletMobileApp.MVVM.Models;
using EwalletMobileApp.Services.Interfaces;
using EwalletMobileApp.Services.Repository;

namespace EwalletMobileApp.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense> _expenseRepository;
        public ExpenseService(IRepository<Expense> expenseRepository, IRepository<Budget> budgetRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task Create(Expense entity)
        {
            await _expenseRepository.Create(entity, false);
        }
        public async Task Delete(int id)
        {
            await _expenseRepository.Delete(id);
        }
        public async Task DeleteAll(IEnumerable<int> ids)
        {
            await _expenseRepository.BulkDelete(ids);
        }

        public async Task<IEnumerable<Expense>?> GetAll(int budgetID, CancellationToken cancellationToken)
        {
            return await _expenseRepository.GetMany(x => x.BudgetID == budgetID, false, cancellationToken);
        }

        public async Task<Expense?> GetByID(int id, CancellationToken cancellationToken)
        {
            return await _expenseRepository.GetByID(id, false, cancellationToken);
        }
        public async Task<Expense?> Update(Expense entity, CancellationToken cancellationToken)
        {
            return await _expenseRepository.Update(entity, cancellationToken);
        }

    }
}
