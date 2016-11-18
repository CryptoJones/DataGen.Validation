namespace Validation.Contracts
{
    public interface IValidatable<T>
    {
        IValidator<T> Validator { set; }

        IValidationResult Validate();
    }
}
