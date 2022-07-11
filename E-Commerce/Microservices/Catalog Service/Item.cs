using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public long Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set;}
    public string Description { get; set;}
    public double UnitPrice { get; set;} 
}