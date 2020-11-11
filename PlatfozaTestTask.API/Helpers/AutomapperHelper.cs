using System;
using AutoMapper;
using PlatfozaTestTask.API.Mapping;

namespace PlatfozaTestTask.API.Helpers
{
    public class AutomapperHelper : IAutomapperHelper
    {
        
        private Mapper _mapper;
        private MapperConfiguration _configuration;
        private IServiceProvider _provider;
        public AutomapperHelper(IServiceProvider provider, AutomapperConfigurationStorage configuration)
        {
            _provider = provider;
            _configuration = configuration.Configuration;
            _mapper = InitializeAutomapper();
        }
        public Mapper InitializeAutomapper() => 
            new Mapper(_configuration, _provider.GetService);

        public Mapper GetAutomapper() => _mapper;
    }
}