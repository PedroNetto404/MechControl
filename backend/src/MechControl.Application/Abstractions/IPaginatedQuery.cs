namespace MechControl.Application.Abstractions;

public interface IPaginatedQuery<TResponse> : IQuery<TResponse>
{
    const int DefaultOffset = 0;
    const int DefaultFetch = 10;
    
    int Offset { get; } 
    int Fetch { get; }
}
