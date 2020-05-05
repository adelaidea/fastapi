using System.Collections.Generic;

namespace FastAPI.Domain.Core.Validation
{
    public class DomainValidation<T>
    {
        T Entity { get; }
        IList<string> Errors { get; set; }
    }
}
