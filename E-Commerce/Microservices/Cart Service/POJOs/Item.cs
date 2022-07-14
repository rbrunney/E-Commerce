public class Item
{
    public string Id { get; set; } = null!;

    public string Name { get; set;} = null!;
    public string? Description { get; set;}
    public double UnitPrice { get; set;}

    public int Quantity {get; set;}
}