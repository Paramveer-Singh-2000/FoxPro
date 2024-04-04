using FoxPro.Auth.Reposititory;
using FoxPro.Auth.ResponseRequestModels;
using FoxPro.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoxPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository<User> _loginRepository;
        public AuthController(ILoginRepository<User> loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(LoginRequestViewModel model)
        {
            var checkUser = await _loginRepository.Login(model);
            
            return Ok(checkUser);
        }
    }
}
