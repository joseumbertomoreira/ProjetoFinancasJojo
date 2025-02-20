using Microsoft.AspNetCore.Mvc;

using MainProject.Models;
using MainProject.Data;
using MainProject.ViewModel;

namespace MainProject.Controllers;

public class ClasseCompraController : Controller
{

    private readonly ApplicationContext _context;

    public ClasseCompraController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {

        var listaClasseCompra = _context.ClassesCompra
            .Select(c => new ClasseCompraViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            })
            .ToList();

        return View(listaClasseCompra);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Nome,Descricao")]ClasseCompraViewModel classeCompraViewModel)
    {
        if(!ModelState.IsValid)
        {
            return View(classeCompraViewModel);
        }

        var classeCompra = new ClasseCompra()
        {
            Nome = classeCompraViewModel.Nome,
            Descricao = classeCompraViewModel.Descricao
        };

        _context.ClassesCompra.Add(classeCompra);
        _context.SaveChanges();

        return RedirectToAction(nameof(List));

    }

    public IActionResult Edit(int id)
    {

        var classeCompra = _context.ClassesCompra.Find(id);

        var classeCompraViewModel = new ClasseCompraViewModel()
        {
            Id = classeCompra.Id,
            Nome = classeCompra.Nome,
            Descricao = classeCompra.Descricao
        };

        return View(classeCompraViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([Bind("Id,Nome,Descricao")] ClasseCompraViewModel classeCompraViewModel)
    {

        if (!ModelState.IsValid)
        {
            return View(classeCompraViewModel);
        }

        var classeCompra = new ClasseCompra()
        {
            Id = classeCompraViewModel.Id,
            Nome = classeCompraViewModel.Nome,
            Descricao = classeCompraViewModel.Descricao
        };


        _context.ClassesCompra.Update(classeCompra);
        _context.SaveChanges();

        return RedirectToAction(nameof(List));

    }

    public IActionResult Delete(int id)
    {

        var classeCompra = _context.ClassesCompra.Find(id);

        _context.ClassesCompra.Remove(classeCompra);
        _context.SaveChanges();

        return RedirectToAction(nameof(List));

    }

}