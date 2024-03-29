﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Database;
using ShoppingCart.Entities;

namespace ShoppingCart.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly ShoppingCartContext _context;
        private readonly DbSet<Item> _items;

        public ItemRepository(ShoppingCartContext context)
        {
            _context = context;
            _items = _context.Items;
        }

        public IQueryable<Item> GetAll()
        {
            return _items;
        }

        public async Task<int> InsertAsync(Item newEntity)
        {
            await _items.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return newEntity.Id;
        }

        public async Task<Item> FindAsync(int id)
        {
            Item item = await _items.FindAsync(id);

            return item;
        }

        public async Task UpdateAsync(Item updatedEntity)
        {
            _items.Update(updatedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Item entityToDelete)
        {
            _context.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            Item targetItem = await _items.FindAsync(id);

            return targetItem != null;
        }
    }
}
