using Microsoft.AspNetCore.Mvc;

using MainProject.Models;

namespace MainProject.Controllers;

public class ClasseCompraController : Controller
{
    public IActionResult List()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")]ClasseCompra classeCompra)
    {
        if(!ModelState.IsValid)
        {
            return View(classeCompra);
        }


        return RedirectToAction(nameof(List));

    }

}