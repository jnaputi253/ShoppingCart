using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Entities
{
    [Table("CartItems")]
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public Cart Cart { get; set; }
    }
}
