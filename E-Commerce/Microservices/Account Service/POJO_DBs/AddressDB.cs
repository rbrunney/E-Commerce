using Microsoft.EntityFrameworkCore;

public class AddressDB : DbContext
{
    public AddressDB(DbContextOptions<AddressDB> options) : base(options) { }
    public DbSet<Address> Todos => Set<Address>();

    public AddressDB()
    {

    }
}
