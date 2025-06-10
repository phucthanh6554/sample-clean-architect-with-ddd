namespace SalesManagement.Domain.Commons;

public class PagedResult<T>
{
    public int Total;
    
    public IEnumerable<T> Items;

    public PagedResult(int total, IEnumerable<T> items)
    {
        Total = total;
        Items = items;
    }
}