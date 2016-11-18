using System;
using Validation.Contracts;

namespace Validation.Model
{
    public class ValidationRule<T> : IValidationRule<T>
    {
        protected Func<T, bool> Rule { get; set; }

        public string ErrorMessage { get; protected set; }

        public ValidationRule(Func<T, bool> rule, string errorMessage)
        {
            this.Rule = rule;
            this.ErrorMessage = errorMessage;
        }

        public virtual bool Run(T instance)
        {
            return this.Rule(instance);
        }
    }
}
