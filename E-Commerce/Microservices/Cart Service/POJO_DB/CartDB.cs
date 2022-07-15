using Microsoft.EntityFrameworkCore;

public class CartDB : DbContext
{
    public CartDB(DbContextOptions<CartDB> options) : base(options) { }
    public DbSet<Cart> Accounts => Set<Cart>();

    public CartDB()
    {

    }
}
