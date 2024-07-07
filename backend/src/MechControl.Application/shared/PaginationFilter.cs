namespace MechControl.Application.shared;

public record PaginationFilter
{
    public int Fetch { get; }

    public int Offset { get; } 

    public const int DefaultFetch = 10;

    public const int DefaultOffset = 0;

    public PaginationFilter(
        int offset = DefaultOffset, 
        int fetch = DefaultFetch)
    {
        if (offset < 0)
        {
            throw new ArgumentException("Offset must be greater than or equal to 0", nameof(offset));
        }
        
        if (fetch < 1)
        {
            throw new ArgumentException("Fetch must be greater than or equal to 1", nameof(fetch));
        }

        (Fetch, Offset) = (fetch, offset);
    }
    
    public IQueryable<T> Apply<T>(IQueryable<T> query) => query.Skip(Offset).Take(Fetch);
}