using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Contracts
{
    public interface IValidator<T>
    {
        IValidationResult Validate(T instance);
    }
}
