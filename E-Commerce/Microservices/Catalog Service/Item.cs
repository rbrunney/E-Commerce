using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Name { get; set;} = null!;
    public string? Description { get; set;}
    public double UnitPrice { get; set;}
}