using Microsoft.EntityFrameworkCore;
using ShoppingCart.Entities;

namespace ShoppingCart.Database
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ShoppingCartContext(DbContextOptions options) : base(options)
        {
            // Intentionally blank.
        }
    }
}
