namespace FastAPI.Application.Models
{
    public class ServiceResult<T>
    {
        public ServiceResult(T data)
        {
            this.Data = data;
        }

       public T Data { get; private set; }
       
    }
}
