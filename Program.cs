var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapGet("/api/books", async (BooksDbContext context) => Results.Ok(await context.Books.ToListAsync()));

app.MapGet("/api/books/{id}", async (BooksDbContext context, [FromRoute] Guid id) =>
{
    var book = await context.Books.FindAsync(id);
    return book is null ? Results.NotFound() : Results.Ok(book);
});

await app.RunAsync();
