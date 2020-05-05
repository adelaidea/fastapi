using FastAPI.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Administration.Users;

namespace Sample.Infra.DataAccess.Repositories
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
