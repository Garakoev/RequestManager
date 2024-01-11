using FluentValidation;
using FluentValidation.Internal;

namespace RequestManager.Core.Extensions;

public static class IValidatorExtensions
{
    public static Func<TValue, IEnumerable<string>> GetValidateFunc<TEntity, TValue>(this IValidator<TEntity> validator, TEntity instance, Action<ValidationStrategy<TEntity>> options) =>
         new(_ => validator.Validate(instance, options).Errors.Select(x => x.ErrorMessage));
}