using Microsoft.AspNetCore.Mvc;
using module3.Models;

namespace module3.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Save() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
            public IActionResult Save(Product product)
            {
                if (!ModelState.IsValid){
                    ViewBag.menssagemError = "Produto invalido para Cadastro";
                }
               
                return View(product);
            }
    }
}