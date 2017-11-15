﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;
using StoreOfBuild.Web.ViewModels;

namespace StoreOfBuild.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthentication _authtentication;

        public AccountController(IAuthentication authtentication)
        {
            _authtentication = authtentication;
        }
        
        public IActionResult Login()
        {          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {     
            var result = await _authtentication.Autheticate(model.Email,model.Password);    
          
            if(result)
            {
                return RedirectToAction("/");
            }else
            {
                ModelState.AddModelError(string.Empty,"Invalid Login");
                return View();
            }

        }
        

        
    }
}
