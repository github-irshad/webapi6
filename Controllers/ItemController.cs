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
        public IEnumerable<ItemDto>GetRecords(){
               var item = repository.GetItems().Select(item => item.AsDto());
               return item;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item = repository.GetItem(id);
            if(item is null)
                return NotFound();
            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
            Item item = new(){
                id=Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CurrentDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem),new {id = item.id},item.AsDto());

        }

        [HttpPut]
        public ActionResult UpdateItem(Guid id, UpdateItem ItemDto){
            var existingItem = repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }

            Item UpdatedItem = existingItem with {
                Name=ItemDto.Name,
                Price=ItemDto.Price
            };

            repository.UpdateItem(UpdatedItem);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id){
            var existingItem = repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }

            repository.DeleteItem(id);
            return NoContent();

        }

    }
}