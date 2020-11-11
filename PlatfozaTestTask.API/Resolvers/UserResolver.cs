using AutoMapper;
using PlatfozaTestTask.API.Models;
using PlatfozaTestTask.API.Models.DTO;
using PlatfozaTestTask.API.Repositorues;

namespace PlatfozaTestTask.API.Resolvers
{
    public class UserResolver : IValueResolver<CreateUserDTO, User, Account>
    {
        private readonly IRepository<Account> _repository;

        public UserResolver(IRepository<Account> repository) => 
            _repository = repository;

        public Account Resolve(CreateUserDTO source, User destination, Account destMember, ResolutionContext context) => 
            _repository.GetById(source.Account_Id);
    }
}