using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using app.Business.Extensions;

namespace app.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : CustomIdExtension
    {
        IQueryable<TEntity> Query();
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}