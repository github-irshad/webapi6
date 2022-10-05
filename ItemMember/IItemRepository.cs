using webapi6.Entity;

namespace webapi6.ItemMember{
    public interface IItemRepository
    {
        record1 GetRecord(Guid id);
        IEnumerable<record1> GetRecord1s();

        void CreateItem(record1 item);

        void UpdateItem(record1 item);
    }
} 