using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Web.ViewModels;

namespace StoreOfBuild.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IManager _manager;

        public UserController(IManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
           var users =  _manager.ListAll();
           var usersViewModel = users.Select(u => new UserViewModel { Id = u.Id, Email = u.Email});
           return View(usersViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            await _manager.CreateAsync(model.Email, model.Password, model.Role);
            return RedirectToAction("Index");
        }


    }
}