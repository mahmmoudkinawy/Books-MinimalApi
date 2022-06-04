namespace Books.MinimalApi.Dtos;
public class BookDto
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public double Price { get; init; }
    public int Pages { get; init; }
}