using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Entities
{
    [Table("Items")]
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        [Range(0.0, (double) decimal.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
