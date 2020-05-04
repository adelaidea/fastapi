using AutoMapper;
using FastAPI.Application.Models.Models.User;
using FastAPI.Domain.Entities;

namespace FastAPI.Application.Models.Mappings
{
    public class ModelProfile :  Profile
    {
        public ModelProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<User, UserUpdateModel>()
                .ReverseMap()
                .ForMember(x=> x.Password, opt => opt.Ignore());
        }
    }
}
