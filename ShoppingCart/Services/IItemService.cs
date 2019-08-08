using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Entities;

namespace ShoppingCart.Services
{
    public interface IItemService
    {
        IQueryable<Item> GetAllItems();
        Task<int> InsertAsync(Item item);
        Task<Item> FindAsync(int id);
        Task UpdateAsync(Item item);
        Task DeleteAsync(int id);
        Task DeleteManyAsync(IList<Item> itemsToDelete);
    }
}
