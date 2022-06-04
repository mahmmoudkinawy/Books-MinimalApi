namespace Books.MinimalApi.Helpers;
public interface IMinimalValidator
{
    ValidationResult Validate<T>(T model);
}
