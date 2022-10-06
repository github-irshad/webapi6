using webapi6.Entity;

namespace webapi6.ItemMember{
    public interface IItemRepository
    {
        Item GetItemAsync(Guid id);
        IEnumerable<Item>GetItemsAsync();

        void CreateItemAsync(Item item);

        void UpdateItemAsync(Item item);

        void DeleteItemAsync(Guid id);
    }
} 