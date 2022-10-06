using webapi6.Entity;

namespace webapi6.ItemMember{
    public interface IItemRepository
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>>GetItemsAsync();

        Task<Item>GetItembyNameAsync(decimal price);

        Task CreateItemAsync(Item item);

        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(Guid id);
        
        Task DeleteItembyNameAsync(decimal price);
    }
} 