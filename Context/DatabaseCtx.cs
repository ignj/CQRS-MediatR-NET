using Microsoft.EntityFrameworkCore;

public class DatabaseCtx : DbContext
{
    public DbSet<Product> Products { get; set; }
}