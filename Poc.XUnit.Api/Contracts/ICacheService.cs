namespace Poc.XUnit.Api.Contracts;

public interface ICacheService
{
    Task<TResult?> GetOrCreateAsync<TResult>(object key, Func<Task<TResult?>> function, CancellationToken cancellationToken);
}