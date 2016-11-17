using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Core
{
    public interface IValidatable<T>
    {
        Validator<T> Validator { get; set; }

        ValidationResult Validate();
    }

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
                    result.Messages?.Add(rule.Message);
                }
            }

            return result;
        }
    }

    public class ValidationResult
    {
        public IList<string> Messages { get; set; }

        public bool Success { get; set; }

        public ValidationResult()
        {
            this.Success = true;
            this.Messages = new List<string>();
        }
        public override string ToString()
        {
            var newLine = Environment.NewLine;
            var messages = string.Join(newLine, this.Messages);
            return string.Format("Result: {0}{1}Messages:{1}{2}", this.Success, newLine, messages);
        }
    }

    public class ValidationRule<T>
    {
        protected Func<T, bool> Rule { get; set; }

        public string Message { get; set; }

        public ValidationRule(Func<T, bool> rule, string message)
        {
            this.Rule = rule;
            this.Message = message;
        }

        public bool Run(T instance)
        {
            return this.Rule(instance);
        }
    }
}
