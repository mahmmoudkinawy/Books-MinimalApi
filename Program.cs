using Books.MinimalApi.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();
