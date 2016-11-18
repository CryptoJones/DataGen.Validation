using System.Collections.Generic;
using System.Linq;

namespace Validation
{
    public class Validator<T>
    {
        protected IList<ValidationRule<T>> ValidationRules { get; set; }

        public Validator(IEnumerable<ValidationRule<T>> validationRules)
        {
            this.ValidationRules = validationRules.ToList();
        }
        public ValidationResult Validate(T instance)
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
