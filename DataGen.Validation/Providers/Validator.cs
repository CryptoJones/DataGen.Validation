using System.Collections.Generic;
using System.Linq;
using Validation.Contracts;
using Validation.Model;

namespace Validation.Providers
{
    public class Validator<T>:IValidator<T>
    {
        protected IList<IValidationRule<T>> ValidationRules { get; set; }

        public Validator(IEnumerable<IValidationRule<T>> validationRules)
        {
            this.ValidationRules = validationRules.ToList();
        }
        public virtual IValidationResult Validate(T instance)
        {
            var result = new ValidationResult();

            foreach (var rule in this.ValidationRules)
            {
                if (!rule.Run(instance))
                {
                    result.Success = false;
                    result.Errors?.Add(rule.ErrorMessage);
                }
            }

            return result;
        }
    }
}
