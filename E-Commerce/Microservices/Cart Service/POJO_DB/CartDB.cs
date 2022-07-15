using Microsoft.EntityFrameworkCore;

public class CartDB : DbContext
{
    public CartDB(DbContextOptions<CartDB> options) : base(options) { }
    public DbSet<CartItem> Cart => Set<CartItem>();

    public CartDB()
    {

    }
}
