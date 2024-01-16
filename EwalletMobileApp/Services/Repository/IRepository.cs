using EwalletMobileApp.MVVM.Models;
using SQLite;
using System.Linq.Expressions;

namespace EwalletMobileApp.Services.Repository
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> expression, bool withChildren, CancellationToken cancellationToken);
        AsyncTableQuery<T> GetAsTableQuery(Expression<Func<T, bool>>? expression);
        Task<T?> GetByID(int id, bool withChildren, CancellationToken cancellationToken);
        Task<T?> GetSingle(Expression<Func<T, bool>> expression, bool withChildren, CancellationToken cancellationToken);
        Task Create(T entity, bool withChildren);
        Task<T?> Update(T entity, CancellationToken cancellationToken);
        Task Delete(int id);
        Task BulkDelete(IEnumerable<int> ids);
        Task<bool> ExecuteQuery(string query, CancellationToken cancellationToken);
    }
}
