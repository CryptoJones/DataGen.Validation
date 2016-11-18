using System;

namespace Validation
{
    public class ValidationRule<T>
    {
        protected Func<T, bool> Rule { get; set; }

        public string ErrorMessage { get; set; }

        public ValidationRule(Func<T, bool> rule, string errorMessage)
        {
            this.Rule = rule;
            this.ErrorMessage = errorMessage;
        }

        public bool Run(T instance)
        {
            return this.Rule(instance);
        }
    }
}
