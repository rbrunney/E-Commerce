using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Model;

namespace Ser
{
    public class ItemService2
    {
        private readonly IMongoCollection<Item> _item;

        public ItemService2(IOptions<ItemDatabaseSettings> itemDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                itemDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                itemDatabaseSettings.Value.DatabaseName);

            _item = mongoDatabase.GetCollection<Item>(
                itemDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Item>> GetAsync() => 
            await _item.Find(_ => true).ToListAsync();

        public async Task<Item?> GetIdAsync(string id) => 
            await _item.Find(i => i.Id == id).FirstOrDefaultAsync();

        public async Task<Item?> GetNameAsync(string name) =>
            await _item.Find(i => i.Name == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Item item) => 
            await _item.InsertOneAsync(item);

        public async Task UpdateAsync(string id, Item NewItem) => 
            await _item.ReplaceOneAsync(i => i.Id == id, NewItem);

        public async Task RemoveAsync(string name) =>
            await _item.DeleteOneAsync(i => i.Name == name);
    }
}