using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCart.Entities;

namespace ShoppingCart.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<int> InsertAsync(Item item);
        Task<Item> FindAsync(int id);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Item itemToDelete);
        Task DeleteManyAsync(IList<Item> itemsToDelete);
    }
}
