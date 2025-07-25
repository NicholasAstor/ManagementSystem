using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Models;

namespace ManagementSystem.Controllers;

public class LoginController : Controller
{
    private const string userCorreto = "admin@admin.com";
    private const string senhaCorreta = "admin";


    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.User == userCorreto && model.Senha == senhaCorreta)
            {
                ViewBag.MensagemSucesso = "Login realizado com sucesso!";
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Email ou senha inválidos.");
            }
        }
        return View(model);
    }
    
}
