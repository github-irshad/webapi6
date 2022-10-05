using webapi6.Dtos;
using webapi6.Entity;

namespace webapi6.extensions{
    public static class Extensions{
        public static record1Dto AsDto(this record1 item){
            return new record1Dto{
                id = item.id,
                Name = item.Name,
                Price = item.Price,
                CurrentDate = item.CurrentDate

               };

        }
    }
}