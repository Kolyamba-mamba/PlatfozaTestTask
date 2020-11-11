using AutoMapper;

namespace PlatfozaTestTask.API.Mapping
{
    public class AutomapperConfigurationStorage
    {
        public MapperConfiguration Configuration;

        public AutomapperConfigurationStorage()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                new AccountAutomapperConfiguration(cfg);
                new UserAutomapperConfiguration(cfg);
                new CreateUserAutomapperConfiguration(cfg);
            });
        }
    }
}