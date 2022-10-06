using webapi6.Entity;

namespace webapi6.ItemMember{
    

    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> items = new(){
            new Item {id=Guid.NewGuid(),Name="Ghost",Price=9,CurrentDate=DateTimeOffset.UtcNow},
            new Item {id=Guid.NewGuid(),Name="Belly",Price=89,CurrentDate=DateTimeOffset.UtcNow},
            new Item {id=Guid.NewGuid(),Name="Nice",Price=20,CurrentDate=DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItemsAsync()
        {
            return items;
        }
        public Item GetItemAsync(Guid id)
        {
            return items.Where(items => items.id == id).SingleOrDefault();
        }

        public void CreateItemAsync(Item item){
            items.Add(item);
        }
        
        public void UpdateItemAsync(Item item){
            var index = items.FindIndex(existingItem=>existingItem.id==item.id);
            items[index]=item;
        }

        public void DeleteItemAsync(Guid id){
            var index = items.FindIndex(existingItem=>existingItem.id==id);
            items.RemoveAt(index);
        }
    }
}