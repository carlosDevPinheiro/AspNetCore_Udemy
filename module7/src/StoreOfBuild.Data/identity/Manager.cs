
using Microsoft.AspNetCore.Identity;

namespace StoreOfBuild.Data.identity
{
    public class Manager
    {
        public UserManager<ApplicationUser> _userManager { get; }
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Manager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
    }
}