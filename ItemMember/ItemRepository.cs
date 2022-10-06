using webapi6.Entity;

namespace webapi6.ItemMember{
    

    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> items = new(){
            new Item {id=Guid.NewGuid(),Name="Ghost",Price=9,CurrentDate=DateTimeOffset.UtcNow},
            new Item {id=Guid.NewGuid(),Name="Belly",Price=89,CurrentDate=DateTimeOffset.UtcNow},
            new Item {id=Guid.NewGuid(),Name="Nice",Price=20,CurrentDate=DateTimeOffset.UtcNow}
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            var item =  items.Where(items => items.id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task<Item> GetItembyNameAsync(decimal price){
            var item =  items.Where(items => items.Price == price).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item){
            items.Add(item);
            await Task.CompletedTask;
        }
        
        public async Task UpdateItemAsync(Item item){
            var index = items.FindIndex(existingItem=>existingItem.id==item.id);
            items[index]=item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id){
            var index = items.FindIndex(existingItem=>existingItem.id==id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task DeleteItembyNameAsync(decimal price){
            var index = items.FindIndex(existingItem=>existingItem.Price==price);
            items.RemoveAt(index);
            await Task.CompletedTask;

        }
    }
}