using webapi6.Dtos;
using webapi6.Entity;

namespace webapi6.extensions{
    public static class Extensions{
        public static ItemDto AsDto(this Item item){
            return new ItemDto{
                id = item.id,
                Name = item.Name,
                Price = item.Price,
                CurrentDate = item.CurrentDate

               };

        }
    }
}