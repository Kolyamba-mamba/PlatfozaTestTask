using AutoMapper;
using PlatfozaTestTask.API.Models;
using PlatfozaTestTask.API.Models.DTO;
using PlatfozaTestTask.API.Resolvers;

namespace PlatfozaTestTask.API.Mapping
{
    public class CreateUserAutomapperConfiguration
    {
        public CreateUserAutomapperConfiguration(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.Account, act
                    => act.MapFrom<UserResolver>());
        }
    }
}