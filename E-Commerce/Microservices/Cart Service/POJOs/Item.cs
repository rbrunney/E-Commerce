public class CartItem
{
    public string Name { get; set;}
    public int Quantity {get; set;}

    public override string ToString()
    {
        return Name + ":" + Quantity;
    }
}