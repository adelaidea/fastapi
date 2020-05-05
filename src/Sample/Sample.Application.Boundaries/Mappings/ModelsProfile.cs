using AutoMapper;
using Sample.Domain.Administration.Users;
using Sample.Application.Boundaries.Models.Administration.Users;

namespace Sample.Application.Boundaries.Mappings
{
    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<User, UserReadModel>();
            CreateMap<UserAddModel, User>();
            CreateMap<UserUpdateModel, User>();
        }
    }
}
