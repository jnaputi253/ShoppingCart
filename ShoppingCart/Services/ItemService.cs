using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Entities;
using ShoppingCart.Repositories;

namespace ShoppingCart.Services
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _repository;

        public ItemService(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            IEnumerable<Item> storedItems = await _repository.GetAllAsync();

            return storedItems;
        }

        public async Task<int> InsertAsync(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            int newId = await _repository.InsertAsync(item);

            return newId;
        }

        public async Task<Item> FindAsync(int id)
        {
            Item item = await _repository.FindAsync(id);

            return item;
        }

        public async Task UpdateAsync(Item item)
        {
            await _repository.UpdateAsync(item);
        }

        public async Task DeleteAsync(Item itemToDelete)
        {
            await _repository.DeleteAsync(itemToDelete);
        }

        public async Task DeleteManyAsync(IList<Item> itemsToDelete)
        {

            if (itemsToDelete == null || !itemsToDelete.Any())
            {
                throw new ArgumentException("You must provide a valid list of items to delete", nameof(itemsToDelete));
            }

            await _repository.DeleteManyAsync(itemsToDelete);
        }
    }
}
