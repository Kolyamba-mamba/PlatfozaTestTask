using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate.Linq;
using PlatfozaTestTask.API.Helpers;
using PlatfozaTestTask.API.Models;
using PlatfozaTestTask.API.Models.DTO;
using PlatfozaTestTask.API.Repositorues;
using PlatfozaTestTask.API.Services;

namespace PlatfozaTestTask.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly Mapper _mapper;
        private readonly IIdentityService _identityService;

        public UserController(ILogger<UserController> logger, 
            IRepository<User> userRepository,
            IRepository<Account> accountRepository,
            IAutomapperHelper automapperHelper, 
            IIdentityService identityService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _identityService = identityService;
            _mapper = automapperHelper.GetAutomapper();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AccountDTO accountDto)
        {
            if (accountDto == null)
            {
                _logger.LogError("The input data is null");
                return BadRequest("The input data is null");
            }

            var authResult = await _identityService.AuthenticationUserAsunc(accountDto.Login, accountDto.Password, _accountRepository);
            if (authResult.IsSuccess)
                return Ok(authResult);
            return Unauthorized();

        }

        [Authorize]
        [Route("userinfo")]
        [HttpGet]
        public async Task<IActionResult> GetUserinfo()
        {
            var accountId = HttpContext.User.Claims.ElementAt(1).Value;
            var username = HttpContext.User.Identity.Name;
            var user = await _userRepository.Get().FirstOrDefaultAsync(u => u.Name == username 
                                                                            && u.Account.Id.ToString() == accountId);
            if (user == null) return BadRequest();
            var userDto = _mapper.Map<User, UserDTO>(user);
            return Ok(userDto);

        }
        
        [Route("exception")]
        [HttpGet]
        public IActionResult GetException() => 
            throw new Exception("unhandled exception");
        
        [Route("error")]
        [HttpGet]
        public IActionResult GetError() =>
            BadRequest("The requested user is not active");
    }
}