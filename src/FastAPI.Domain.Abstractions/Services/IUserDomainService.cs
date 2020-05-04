using FastAPI.Domain.Entities;
using System.Threading.Tasks;

namespace FastAPI.Domain.Abstractions.Services
{
    public interface IUserDomainService : IDomainService<User>
    {
        
    }
}
