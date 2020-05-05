namespace FastAPI.Application.Models
{
    public class ServiceResult
    {   

        public ServiceResult(params string[] errors)
        {
            this.Errors = errors;
        }

        public string[] Errors { get; private set; }

    }
}
