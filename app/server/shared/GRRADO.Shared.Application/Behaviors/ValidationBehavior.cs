using FluentValidation;
using MediatR;
using GRRADO.Shared.Application.Common;

namespace GRRADO.Shared.Application.Behaviors;

/// <summary>
/// MediatR pipeline behavior that runs FluentValidation validators before the handler.
/// Returns Result.Failure with validation errors instead of throwing exceptions.
/// </summary>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count == 0)
            return await next();

        var errors = string.Join("; ", failures.Select(f => f.ErrorMessage));

        // Handle Result<T> return type
        var responseType = typeof(TResponse);
        if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
        {
            var failureMethod = responseType.GetMethod(nameof(Result.Failure), new[] { typeof(string) });
            if (failureMethod != null)
                return (TResponse)failureMethod.Invoke(null, new object[] { errors })!;
        }

        // Handle non-generic Result return type
        if (responseType == typeof(Result))
            return (TResponse)(object)Result.Failure(errors);

        // Fallback: throw ValidationException for unrecognized return types
        throw new ValidationException(failures);
    }
}
