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
                itemDatabaseSettings.Value.ItemDb);

            _item = mongoDatabase.GetCollection<Item>(
                itemDatabaseSettings.Value.Items);
        }

        public async Task<List<Item>> GetAsync() => 
            await _item.Find(_ => true).ToListAsync();

        public async Task<Item?> GetAsync(long id) => 
            await _item.Find(i => i.Id == id).FirstOrDefaultAsync();

        public async Task<Item?> GetAsync(string name) =>
            await _item.Find(i => i.Name == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Item item) => 
            await _item.InsertOneAsync(item);

        public async Task UpdateAsync(long id, Item NewItem) => 
            await _item.ReplaceOneAsync(i => i.Id == id, NewItem);

        public async Task RemoveAsync(long id) =>
            await _item.DeleteOneAsync(i => i.Id == id);
    }
}