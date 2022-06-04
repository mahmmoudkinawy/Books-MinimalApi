namespace Books.MinimalApi.Dtos;
public class BookCreateDto
{
    [Required]
    [MaxLength(256)]
    [MinLength(2)]
    public string Name { get; init; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public double Price { get; init; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int Pages { get; init; }
}