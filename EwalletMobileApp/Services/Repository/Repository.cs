using EwalletMobileApp.MVVM.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System.Linq.Expressions;

namespace EwalletMobileApp.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly SQLiteAsyncConnection _asyncConnection;
        private readonly AsyncTableQuery<T> _table;
        public Repository(SQLiteAsyncConnection asyncConnection)
        {
            _asyncConnection = asyncConnection;
            _asyncConnection.CreateTableAsync<T>().Wait();
            _table = _asyncConnection.Table<T>();
        }

        public async Task Create(T entity, bool withChildren)
        {
            entity.SetCreationDate();

            if (withChildren)
            {
                await _asyncConnection.InsertWithChildrenAsync(entity, false);
            }
            else
            {
                await _asyncConnection.InsertAsync(entity);
            }
        }
        public async Task Delete(int id)
        {
            await _asyncConnection.DeleteAsync(id);
        }
        public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> expression, bool withChildren, CancellationToken cancellationToken)
        {
            if (withChildren)
            {
                await _asyncConnection.GetAllWithChildrenAsync<T>(expression, false, cancellationToken);
            }
            return await _table.Where(expression).ToListAsync();
        }
        public async Task<T?> GetByID(int id, bool withChildren, CancellationToken cancellationToken)
        {
            if (withChildren)
            {
                return await _asyncConnection.FindWithChildrenAsync<T>(id, false, cancellationToken);
            }
            return await _asyncConnection.FindAsync<T>(id);
        }
        public async Task<T?> GetSingle(Expression<Func<T, bool>> expression, bool withChildren, CancellationToken cancellationToken)
        {
            var entity = await _table.FirstOrDefaultAsync(expression);

            if (entity is not null && withChildren)
            {
                return await _asyncConnection.GetWithChildrenAsync<T>(entity.ID, false, cancellationToken);
            }
            return entity;
        }
        public async Task<T?> Update(T entity, CancellationToken cancellationToken)
        {
            int updated = await _asyncConnection.UpdateAsync(entity);
            if (updated > 0)
            {
                return entity;
            }
            return null;
        }
        public AsyncTableQuery<T> GetAsTableQuery(Expression<Func<T, bool>>? expression)
        {
            if (expression is not null)
            {
                return _table.Where(expression);
            }
            return _table;
        }
        public async Task BulkDelete(IEnumerable<int> ids)
        {
            await _table.DeleteAsync(x => ids.Contains(x.ID));
        }
        public async Task<bool> ExecuteQuery(string query, CancellationToken cancellationToken)
        {
            return await _asyncConnection.ExecuteAsync(query) > 0;
        }

    }
}
