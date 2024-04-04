using FoxPro.Auth.Entities;
using FoxPro.Auth.Reposititory;
using FoxPro.Auth.ResponseRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxPro.Auth.Services
{
    public class AccountService<TUser> : IAccountService<TUser> where TUser : ApplicationUser
    {
        private readonly ILoginRepository<TUser> loginRepo;
        public AccountService(ILoginRepository<TUser> loginRepository)
        {
            loginRepo = loginRepository;
        }
        public async Task<LoginResponseViewModel> Login(LoginRequestViewModel loginViewModel)
        {
            try
            {
                var res = await loginRepo.Login(loginViewModel);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> SignUp(TUser signUpModel, string password)
        {
            try
            {
                var res = await loginRepo.SignUp(signUpModel, password);
                if (res)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TokenModel> RefreshToken(TokenModel model)
        {
            try
            {
                var res = await loginRepo.RefreshToken(model);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
