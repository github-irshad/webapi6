using webapi6.Entity;

namespace webapi6.ItemMember{
    

    public class ItemRepository : IItemRepository
    {
        private readonly List<record1> items = new(){
            new record1 {id=Guid.NewGuid(),Name="Ghost",Price=9,CurrentDate=DateTimeOffset.UtcNow},
            new record1 {id=Guid.NewGuid(),Name="Belly",Price=89,CurrentDate=DateTimeOffset.UtcNow},
            new record1 {id=Guid.NewGuid(),Name="Nice",Price=20,CurrentDate=DateTimeOffset.UtcNow}
        };

        public IEnumerable<record1> GetRecord1s()
        {
            return items;
        }
        public record1 GetRecord(Guid id)
        {
            return items.Where(items => items.id == id).SingleOrDefault();
        }

        public void CreateItem(record1 item){
            items.Add(item);
        }
        
        public void UpdateItem(record1 item){
            var index = items.FindIndex(existingItem=>existingItem.id==item.id);
            items[index]=item;
        }

        public void DeleteItem(Guid id){
            var index = items.FindIndex(existingItem=>existingItem.id==id);
            items.RemoveAt(index);
        }
    }
}