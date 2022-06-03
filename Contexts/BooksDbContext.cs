namespace Books.MinimalApi.Contexts;
public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    { }

    public DbSet<BookEntity> Books => Set<BookEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookEntity>()
            .HasData(
                new BookEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "C# In Nutshell",
                    Pages = 900,
                    Price = 35
                },
                new BookEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "JAVA",
                    Pages = 620,
                    Price = 23
                },
                new BookEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "How to make Hawawshi?",
                    Pages = 66,
                    Price = 8
                });

    }

}