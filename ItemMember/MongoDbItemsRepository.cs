using MongoDB.Bson;
using MongoDB.Driver;
using webapi6.Entity;

namespace webapi6.ItemMember{
  public class MongoDbItemsRepository : IItemRepository
  {

    private const string databaseName = "catalog";
    private const string collectionName = "items";

    private readonly IMongoCollection<Item>itemsCollection;
    public MongoDbItemsRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      itemsCollection = database.GetCollection<Item>(collectionName);
    }

    private readonly FilterDefinitionBuilder<Item>filterBuilder = Builders<Item>.Filter;

    public async Task CreateItemAsync(Item item)
    {
      await itemsCollection.InsertOneAsync(item); 
    }

    public async Task DeleteItemAsync(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.id, id);
      await itemsCollection.DeleteOneAsync(filter);
    }

    public async Task<Item> GetItemAsync(Guid id)
    {
      var filter = filterBuilder.Eq(item =>item.id,id );
      return await itemsCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
      return await itemsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateItemAsync(Item item)
    {
      var filter = filterBuilder.Eq(existingItem => existingItem.id , item.id);
      await itemsCollection.ReplaceOneAsync(filter,item);
    }
    public async Task<Item> GetItembyNameAsync(decimal price)
    {
      var filter = filterBuilder.Eq(item =>item.Price,price );
      return await itemsCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task DeleteItembyNameAsync(decimal price)
    {
      var filter = filterBuilder.Eq(item => item.Price, price);
      await itemsCollection.DeleteOneAsync(filter);
    }
    
  }
}
