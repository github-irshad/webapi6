using MongoDB.Bson;
using MongoDB.Driver;
using webapi6.Entity;

namespace webapi6.ItemMember{
  public class MongoDbItemsRepository : IItemRepository{

    private const string databaseName = "catalog";
    private const string collectionName = "items";

    private readonly IMongoCollection<Item>itemsCollection;
    public MongoDbItemsRepository(IMongoClient mongoClient){
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      itemsCollection = database.GetCollection<Item>(collectionName);
    }

    private readonly FilterDefinitionBuilder<Item>filterBuilder = Builders<Item>.Filter;

    public void CreateItem(Item item)
    {
      itemsCollection.InsertOne(item);
    }

    public void DeleteItem(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.id, id);
      itemsCollection.DeleteOne(filter);
    }

    public Item GetItemAsync(Guid id)
    {
      var filter = filterBuilder.Eq(item =>item.id,id );
      return itemsCollection.Find(filter).SingleOrDefault();
    }

    public IEnumerable<Item> GetItems()
    {
      return itemsCollection.Find(new BsonDocument()).ToList();
    }

    public void UpdateItem(Item item)
    {
      var filter = filterBuilder.Eq(existingItem => existingItem.id , item.id);
      itemsCollection.ReplaceOne(filter,item);
    }
  }
}