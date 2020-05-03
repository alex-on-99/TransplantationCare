using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;

namespace TransplantationCare.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TransplantationCareContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(TransplantationCareContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity item)
        {
            await dbSet.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public Task RemoveAsync(TEntity item)
        {
            dbSet.Remove(item);
            return context.SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public Task UpdateAsync(TEntity item)
        {
            dbSet.Update(item);
            return context.SaveChangesAsync();
        }
    }
}
