using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<int> InsertAsync(TEntity newEntity);
        Task<TEntity> FindAsync(int id);
        Task UpdateAsync(TEntity updatedEntity);
        Task DeleteAsync(TEntity entityToDelete);
        Task DeleteManyAsync(IEnumerable<TEntity> entitiesToDelete);
        Task<bool> ExistsAsync(int id);
    }
}
