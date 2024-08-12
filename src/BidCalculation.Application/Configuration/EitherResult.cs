namespace BidCalculation.Application.Configuration;

public class EitherResult<TSuccess, TError>
{
    private readonly TSuccess? _success;
    private readonly TError? _error;

    public TSuccess? Value => _success;
    public TError? Error => _error;
    public bool IsError { get;}
    
    private EitherResult(TSuccess success)
    {
        _success = success;
    }

    private EitherResult(TError error)
    {
        IsError = true;
        _error = error;
    }

    public T Match<T>(Func<TSuccess, T> success, Func<TError, T> error)
    {
        return !IsError ? success(_success!) : error(_error!);
    }

    public static implicit operator EitherResult<TSuccess, TError>(TSuccess value)
    {
        return new EitherResult<TSuccess, TError>(value);
    }

    public static implicit operator EitherResult<TSuccess, TError>(TError error)
    {
        return new EitherResult<TSuccess, TError>(error);
    }
}