namespace Books.MinimalApi.Entities;
public class BookEntity
{
    public Guid Id { get; set; }
    public string Name { get; init; } = default!;
    public double Price { get; init; } = default!;
    public int Pages { get; init; } = default!;
}
