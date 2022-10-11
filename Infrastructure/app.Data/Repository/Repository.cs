using app.Business.Extensions;
using app.Business.Interfaces.Repositories;
using app.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace app.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : CustomIdExtension, new()
    {
        protected readonly ApiDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApiDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return DbSet.AsNoTracking().AsQueryable();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await DbSet.AsNoTracking().FirstAsync(i => i.Id == id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            TEntity entityDb = await DbSet.FindAsync(id);
            if (entityDb != null)
            {
                Db.Entry(entityDb).State = EntityState.Deleted;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}