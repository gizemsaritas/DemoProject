using AutoMapper;
using DemoProject.DTO.Concrete.AppUser;
using DemoProject.Entities.Concrete;

namespace DemoProject.WebApi.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, AppSignInDto>().ReverseMap();
        }
    }
}
