using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;
using StoreOfBuild.Web.ViewModels;

namespace StoreOfBuild.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly CategoryStores _categoryStories;

        public IRepository<Category> _repositoryCatgory { get; }

        public CategoryController(CategoryStores categoryStories, IRepository<Category> repository)
        {
            _categoryStories = categoryStories;
            _repositoryCatgory = repository;
        }
        public IActionResult Index()
        {
            var categories = _repositoryCatgory.All();
            var viewModels = categories.Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name });
            return View(viewModels);
        }

        public IActionResult CreateOrEdit(int id)
        {
            if (id > 0)
            {
                var category = _repositoryCatgory.GetById(id);
                var viewModel = new CategoryViewModel { Id = category.Id, Name = category.Name };
                return View(viewModel);
            } else 
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
            _categoryStories.Store(viewModel.Id, viewModel.Name);
            return RedirectToAction("Index");
        }
    }
}
