using AutoMapper;
using PlatfozaTestTask.API.Models;
using PlatfozaTestTask.API.Models.DTO;

namespace PlatfozaTestTask.API.Mapping
{
    public class UserAutomapperConfiguration
    {
        public UserAutomapperConfiguration(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserDTO>()
                .ForMember(dest => dest.BirthDate, act 
                    => act.MapFrom(src => src.BirthDate.ToString("yyyy.MM.dd")));
        }
    }
}