using System;
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

        public IQueryable<Item> GetAllItems()
        {
            return _repository.GetAll();
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
    }
}
