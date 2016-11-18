using System;
using System.Collections.Generic;

namespace Validation
{
    public class ValidationResult
    {
        // Refactor: encapsulate collection
        public IList<string> Errors { get; set; }

        public bool Success { get; set; }

        public ValidationResult()
        {
            this.Success = true;
            this.Errors = new List<string>();
        }
        public override string ToString()
        {
            var newLine = Environment.NewLine;
            var errors = string.Join(newLine, this.Errors);
            return string.Format("Result: {0}{1}Errors:{1}{2}", this.Success, newLine, errors);
        }
    }
}
