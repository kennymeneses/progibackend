namespace BidCalculation.Application.Configuration;

public class EitherResult<TSuccess, TError>
{
    private readonly TSuccess _success;
    private readonly TError _error;
    private readonly bool _isError;

    public EitherResult(TSuccess success)
    {
        _success = success;
        _isError = false;
    }

    public EitherResult(TError error)
    {
        _error = error;
        _isError = true;
    }

    public T Match<T>(Func<TSuccess, T> success, Func<TError, T> error)
    {
        return !_isError ? success(_success) : error(_error);
    }
}