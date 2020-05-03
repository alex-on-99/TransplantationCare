using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task RemoveAsync(TEntity item);
    }
}
