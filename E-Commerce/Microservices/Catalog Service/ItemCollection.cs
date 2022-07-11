using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class ItemCollection
{
    public IMongoCollection<Item> Items { get; }

    public ItemCollection()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("ItemDb");
        Items = database.GetCollection<Item>("Items");
    }
}