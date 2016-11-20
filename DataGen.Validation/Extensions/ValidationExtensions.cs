using Validation.Contracts;

namespace DataGen.Validation
{
    public static class ValidationExtensions
    {
        public static IValidationResult Validate<T>(this T instance, IValidator<T> validator)
        {
            return validator.Validate(instance);
        }
    }
}
