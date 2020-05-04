namespace FastAPI.Application.Models
{
    public class ServiceResult<T>
    {
        public ServiceResult(T data)
        {
            this.Data = data;
        }

        public ServiceResult(params string[] errors)
        {
            this.Errors = errors;
        }

        public T Data { get; private set; }

        public string[] Errors { get; private set; }

    }
}
