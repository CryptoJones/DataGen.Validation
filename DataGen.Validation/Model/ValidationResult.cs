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
            this.Errors = new List<string>();
        }
       
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        public void Clear()
        {
            this.Errors.Clear();
        }

        public bool Contains(string error)
        {
            return this.Errors.Contains(error);
        }
    }
}
