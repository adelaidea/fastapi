using FastAPI.Application.Abstraction.Service.Administration;
using FastAPI.Application.Models.Models.User;
using FastAPI.Domain.Entities;
using FastAPI.Sample.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace FastAPI.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : CrudController<User, int, UserModel, UserModel>
    {        
        public UserController(IUserApplicationService service) : base(service)
        {

        }
    }
}