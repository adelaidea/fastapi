using FastAPI.Application.Abstraction.Service.Administration;
using FastAPI.Application.Models.Models.User;
using FastAPI.Domain.Entities;
using FastAPI.Sample.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace FastAPI.Sample.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : CrudController<User, int, UserModel, UserUpdateModel>
    {        
        public UserController(IUserApplicationService service) : base(service)
        {}
    
    }
}