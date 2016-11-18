using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validation
{
    public interface IValidatable<T>
    {
        Validator<T> Validator { get; set; }

        ValidationResult Validate();
    }
}
