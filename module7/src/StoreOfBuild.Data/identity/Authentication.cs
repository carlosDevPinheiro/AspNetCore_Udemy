using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;

namespace StoreOfBuild.Data.identity
{
    public class Authentication: IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Authentication(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Autheticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email,password,false,lockoutOnFailure:true);
            return result.Succeeded;
        }
    }
}