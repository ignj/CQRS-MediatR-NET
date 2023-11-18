using Microsoft.EntityFrameworkCore;

public class DatabaseCtx : DbContext
{
    public DatabaseCtx(DbContextOptions<DatabaseCtx> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}