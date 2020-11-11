using AutoMapper;
using PlatfozaTestTask.API.Models;
using PlatfozaTestTask.API.Models.DTO;

namespace PlatfozaTestTask.API.Mapping
{
    public class AccountAutomapperConfiguration
    {
        public AccountAutomapperConfiguration(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AccountDTO, Account>();
        }
    }
}