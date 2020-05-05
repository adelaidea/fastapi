using FastAPI.Sample.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.Administration.Users;
using Sample.Application.Boundaries.Models.Administration.Users;
using Sample.Application.Boundaries.Services;

namespace FastAPI.Sample.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : CrudController<User, int, UserAddModel, UserUpdateModel, UserReadModel>
    {        
        public UserController(IUserApplicationService service) : base(service)
        {}
    
    }
}