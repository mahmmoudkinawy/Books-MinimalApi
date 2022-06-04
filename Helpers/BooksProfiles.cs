namespace Books.MinimalApi.Helpers;
public class BooksProfiles : Profile
{
    public BooksProfiles()
    {
        CreateMap<BookEntity, BookDto>();
    }
}