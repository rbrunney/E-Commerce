public class CartItem
{
    public int Id {get; set;}
    public string? Name { get; set;}
    public int Quantity {get; set;}
    
    public CartItem(int id, string Name, int Quantity)
    {
        this.Id = id;
        this.Name = Name;
        this.Quantity = Quantity;
    }

    public override string ToString()
    {
        return Name + ":" + Quantity;
    }
}