using EwalletMobileApp.MVVM.Models;
using SQLite;

namespace EwalletMobileApp.Services
{
    public abstract class BaseService<T> where T : BaseEntity, new()
    {
        protected async Task<IEnumerable<T>> GetRequestedItems(AsyncTableQuery<T> query, int currentPage, int pageSize)
        {
            int skip = (currentPage - 1) * pageSize;

            return await query.OrderByDescending(x => x.ID)
                              .Skip(skip)
                              .Take(pageSize)
                              .ToListAsync();
        }
    }
}
