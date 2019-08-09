using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
            IQueryable<Item> storedItems = _items.FromSql("sp_GetAllItems");

            return storedItems;
        }

        public async Task<int> InsertAsync(Item newEntity)
        {
            await _items.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return newEntity.Id;
        }

        public async Task<Item> FindAsync(int id)
        {
            var idParameter = new SqlParameter("@Id", id);


            Item item = await _items.FromSql("EXEC sp_FindItemById @Id", idParameter)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task UpdateAsync(Item updatedEntity)
        {
            var idParameter = new SqlParameter("@Id", updatedEntity.Id);
            var nameParameter = new SqlParameter("@Name", updatedEntity.Name);
            var descriptionParameter = new SqlParameter("@Description", updatedEntity.Description);
            var priceParameter = new SqlParameter("@Price", updatedEntity.Price);

            int updateCount = await _context.Database.ExecuteSqlCommandAsync(
                "EXEC sp_UpdateItem @Id, @Name, @Description, @Price",
                idParameter, nameParameter, descriptionParameter, priceParameter);
        }

        public async Task DeleteAsync(int id)
        {
            var idParameter = new SqlParameter("@Id", id);

            await _context.Database
                .ExecuteSqlCommandAsync("EXEC sp_DeleteItem @Id", idParameter);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            Item targetItem = await _items.FindAsync(id);

            return targetItem != null;
        }
    }
}
