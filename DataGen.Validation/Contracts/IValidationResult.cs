using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Contracts
{
    public interface IValidationResult
    {
        bool Success { get; set; }

        IList<string> Errors { get; }

        void AddError(string error);

        void Clear();

        bool Contains(string error);
    }
}
