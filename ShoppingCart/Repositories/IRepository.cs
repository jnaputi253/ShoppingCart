﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<int> InsertAsync(TEntity newEntity);
        Task<TEntity> FindAsync(int id);
        Task UpdateAsync(TEntity updatedEntity);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<TEntity> entitiesToDelete);
        Task<bool> ExistsAsync(int id);
    }
}
