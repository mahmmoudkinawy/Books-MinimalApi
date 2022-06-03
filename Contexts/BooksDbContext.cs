namespace Books.MinimalApi.Contexts;
public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    { }

    public DbSet<BookEntity> Books => Set<BookEntity>();
}