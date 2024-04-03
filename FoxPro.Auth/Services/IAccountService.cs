using FoxPro.Auth.Entities;
using FoxPro.Auth.ResponseRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxPro.Auth.Services
{
    public interface IAccountService<TUser> where TUser : ApplicationUser
    {
        Task<LoginResponseViewModel> Login(LoginRequestViewModel loginModel);
        Task<bool> SignUp(TUser signUpModel, string Password);

        Task<TokenModel> RefreshToken(TokenModel tokenModel);

    }
}
