
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;

namespace StoreOfBuild.Data.identity
{
    public class Manager: IManager
    {
        private UserManager<ApplicationUser> _userManager { get; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _dbContext { get; }

        public Manager(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(string email, string password, string role)
        {
            var user = new ApplicationUser { UserName= email, Email = email};
            var result = await _userManager.CreateAsync(user,password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,role);
                return true;
            }

            return false;
        }

        public IList<IUser> ListAll()
        {
            var users = _dbContext.Users;
            return users.Any() ? users.Select(u => (IUser)u).ToList() : new List<IUser>();
        }
    }
}