using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PlatfozaTestTask.API.Helpers;
using PlatfozaTestTask.API.Models;
using PlatfozaTestTask.API.Models.DTO;
using PlatfozaTestTask.API.Repositorues;

namespace PlatfozaTestTask.API.Services
{
    public class DbInitializer
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly Mapper _mapper;

        public DbInitializer(IRepository<User> userRepository,
            IAutomapperHelper automapperHelper, IRepository<Account> accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _mapper = automapperHelper.GetAutomapper();
        }

        public void Initialize()
        {
            if (!_accountRepository.Get().Any())
                AddAccount();
            else if (!_userRepository.Get().Any() && _accountRepository.Get().Any()) 
                AddUser();
        }

        private void AddAccount()
        {
            var accountDtoList = new List<AccountDTO>
            {
                new AccountDTO
                {
                    Login = "Test",
                    Password = "Test"
                },
                new AccountDTO
                {
                    Login = "Nikolay",
                    Password = "1234"
                },
                new AccountDTO
                {
                    Login = "Admin",
                    Password = "Admin"
                } 
            };
            foreach (var accountDto in accountDtoList)
                _accountRepository.Create(_mapper.Map<AccountDTO, Account>(accountDto));
        }

        private void AddUser()
        {
            var accounts = _accountRepository.Get().ToList();
            var userDtoList = new List<CreateUserDTO>
            {
                new CreateUserDTO
                {
                    Name = "Test",
                    BirthDate = new DateTime(1998, 11, 10),
                    Amount = 100,
                    Account_Id = accounts[0].Id
                },
                new CreateUserDTO
                {
                    Name = "Nikolay",
                    BirthDate = new DateTime(1990, 9, 4),
                    Amount = 200,
                    Account_Id = accounts[1].Id
                },
                new CreateUserDTO
                {
                    Name = "Admin",
                    BirthDate = new DateTime(1988, 7, 1),
                    Amount = 300,
                    Account_Id = accounts[2].Id
                }
            };
            foreach (var userDto in userDtoList) 
                _userRepository.Create(_mapper.Map<CreateUserDTO, User>(userDto));
        }
    }
}