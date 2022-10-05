using Microsoft.AspNetCore.Mvc;
using webapi6.Dtos;
using webapi6.Entity;
using webapi6.extensions;
using webapi6.ItemMember;

namespace webapi6.Controller{
    [ApiController]
    [Route("[controller]")]
    public class record1Controller : ControllerBase{
        private readonly IItemRepository repository;

        public record1Controller(IItemRepository repository){
            this.repository = repository;

        }
        [HttpGet]
        public IEnumerable<record1Dto>GetRecords(){
               var item = repository.GetRecord1s().Select(item => item.AsDto());
               return item;
        }

        [HttpGet("{id}")]
        public ActionResult<record1Dto> GetItem(Guid id){
            var item = repository.GetRecord(id);
            if(item is null)
                return NotFound();
            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<record1Dto> CreateItem(CreateItemDto itemDto){
            record1 item = new(){
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
            var existingItem = repository.GetRecord(id);
            if(existingItem is null){
                return NotFound();
            }

            record1 UpdatedItem = existingItem with {
                Name=ItemDto.Name,
                Price=ItemDto.Price
            };

            repository.UpdateItem(UpdatedItem);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id){
            var existingItem = repository.GetRecord(id);
            if(existingItem is null){
                return NotFound();
            }

            repository.DeleteItem(id);
            return NoContent();

        }

    }
}