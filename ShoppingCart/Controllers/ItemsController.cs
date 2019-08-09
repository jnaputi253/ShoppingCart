using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Entities;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemsController(IItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            IQueryable<Item> items = _service.GetAllItems();

            return new ObjectResult(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetItemAsync([FromRoute] int id)
        {
            Item item = await _service.FindAsync(id);

            return new OkObjectResult(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync(
            [Bind(nameof(Item.Name), nameof(Item.Description), nameof(Item.Price))] Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int newItemId = await _service.InsertAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new {id = newItemId}, item);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateItemAsync(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.UpdateAsync(item);

            return Ok();
        }

        [HttpDelete("delete/{id:int?}")]
        public async Task<IActionResult> DeleteItemAsync(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { message = "The selected item is invalid" });
            }

            Item item = await _service.FindAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id.Value);

            return Ok();
        }
    }
}
