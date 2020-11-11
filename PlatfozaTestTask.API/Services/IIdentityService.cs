using System.Threading.Tasks;
using PlatfozaTestTask.API.Models;
using PlatfozaTestTask.API.Repositorues;

namespace PlatfozaTestTask.API.Services
{
    public interface IIdentityService
    {
        Task<AuthResult> AuthenticationUserAsunc(string login, string password, IRepository<Account> repository);
    }
}