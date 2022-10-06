using Microsoft.AspNetCore.Mvc;
using webapi6.Dtos;
using webapi6.Entity;
using webapi6.extensions;
using webapi6.ItemMember;

namespace webapi6.Controller{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase{
        private readonly IItemRepository repository;

        public ItemController(IItemRepository repository){
            this.repository = repository;

        }
        [HttpGet]
        public async Task< IEnumerable<ItemDto>>GetItemsAsync(){
               var item = (await repository.GetItemsAsync()).Select(item => item.AsDto());
               return item;
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<ItemDto>> GetItemAsync(Guid id){
            var item = await repository.GetItemAsync(id);
            if(item is null)
                return NotFound();
            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto){
            Item item = new(){
                id=Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CurrentDate = DateTimeOffset.UtcNow
            };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync),new {id = item.id},item.AsDto());

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItem ItemDto){
            var existingItem = await repository.GetItemAsync(id);
            if(existingItem is null){
                return NotFound();
            }

            Item UpdatedItem = existingItem with {
                Name=ItemDto.Name,
                Price=ItemDto.Price
            };

            await repository.UpdateItemAsync(UpdatedItem);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id){
            var existingItem = await repository.GetItemAsync(id);
            if(existingItem is null){
                return NotFound();
            }

            await repository.DeleteItemAsync(id);
            return NoContent();

        }

        [HttpDelete("{price}")]
        public async Task<ActionResult> DeleteItemsbyNameAsync(decimal price){
            var existingItem = await repository.GetItembyNameAsync(price);
            if(existingItem is null){
                return NotFound();
            }

            await repository.DeleteItembyNameAsync(price);
            return NoContent();
        }

    }
}