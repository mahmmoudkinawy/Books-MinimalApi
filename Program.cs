var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMinimalValidator, MinimalValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapGet("/api/books", async (BooksDbContext context, IMapper mapper) =>
        Results.Ok(mapper.Map<IReadOnlyList<BookEntity>>(await context.Books.ToListAsync())));

app.MapGet("/api/books/{id}", async (BooksDbContext context, [FromRoute] Guid id, IMapper mapper) =>
{
    var book = await context.Books.FindAsync(id);

    if (book == null) return Results.NotFound();

    return Results.Ok(mapper.Map<BookEntity>(book));
});

app.MapPost("/api/books", async (BooksDbContext context,
    [FromBody] BookCreateDto bookCreateDto,
    IMinimalValidator minimalValidator,
    IMapper mapper) =>
{
    var validationResult = minimalValidator.Validate(bookCreateDto);

    if (validationResult.IsValid)
    {
        var createdBook = mapper.Map<BookEntity>(bookCreateDto);

        context.Books.Add(createdBook);
        await context.SaveChangesAsync();

        return Results.Created($"/api/books/{createdBook.Id}", createdBook);
    }

    return Results.ValidationProblem(validationResult.Errors);
});

await app.RunAsync();
