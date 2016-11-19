using System;
using System.Collections.Generic;
using Validation.Contracts;

namespace Validation.Model
{
    public class ValidationResult : IValidationResult
    {
        public bool Success { get; set; }

        public IList<string> Errors { get; protected set; }

        public ValidationResult()
        {
            this.Success = true;
            this.InitializeErrors();
        }
       
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        public void ClearErrors()
        {
            this.Errors.Clear();
        }

        public bool ContainsError(string error)
        {
            return this.Errors.Contains(error);
        }

        public void InitializeErrors()
        {
            this.Errors = new List<string>();
        }
    }
}
