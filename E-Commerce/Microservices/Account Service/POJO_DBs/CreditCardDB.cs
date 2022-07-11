using Microsoft.EntityFrameworkCore;

public class CreditCardDB : DbContext
{
    public CreditCardDB(DbContextOptions<CreditCardDB> options) : base(options) { }
    public DbSet<CreditCard> Todos => Set<CreditCard>();

    public CreditCardDB()
    {

    }
}
