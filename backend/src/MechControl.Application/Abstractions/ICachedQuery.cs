namespace MechControl.Application.Abstractions;

public interface ICachedQuery
{
    string CacheKey { get; }
    TimeSpan? SlidingExpiration { get; }
}

public interface ICachedQuery<TResponse> : 
    IQuery<TResponse>, 
    ICachedQuery;