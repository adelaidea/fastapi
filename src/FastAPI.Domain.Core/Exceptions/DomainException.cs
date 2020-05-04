using System;

namespace FastAPI.Domain.Core.Exceptions
{
    public class DomainException : Exception
    {
        public string[] Errors { get; set; }
        
        public DomainException(params string[] errors)
        {
            this.Errors = errors;
        }
    }
}
