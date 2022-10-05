namespace webapi6.ItemMember{
  public class MongoDbItemsRepository : IItemRepository{

    private const string databaseName = "catalog";
    private const string collectionName = "items";
    public MongoDbItemsRepository(IMongoClient mongoClient){
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
    }
  }
}