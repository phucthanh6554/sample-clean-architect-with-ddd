namespace SalesManagement.Domain.Commons;

public class CreateEntityResult<T>
{
    public T? Entity { get; init; }
    
    public bool IsSuccess { get; init; }
    
    public string ErrorMessage { get; init; } = string.Empty;

    public CreateEntityResult(T entity)
    {
        Entity = entity;
        IsSuccess = true;
    }

    public CreateEntityResult(string errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }
}