using AutoMapper;

namespace PlatfozaTestTask.API.Helpers
{
    public interface IAutomapperHelper
    {
        Mapper InitializeAutomapper();
        Mapper GetAutomapper();
    }
}