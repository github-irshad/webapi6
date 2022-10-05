using webapi6.Entity;

namespace webapi6.ItemMember{
    public interface IItemRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item>GetItems();

        void CreateItem(Item item);

        void UpdateItem(Item item);

        void DeleteItem(Guid id);
    }
} 