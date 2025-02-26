using MainProject.Data;
using MainProject.Models;
using MainProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Controllers;

public class CompraController : Controller
{

    private readonly ApplicationContext _context;

    public CompraController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {

        var listaCompras = _context.Compras
            .Select(c => new CompraViewModel
            {
                Id = c.Id,
                Descricao = c.Descricao,
                Valor = c.Valor,
                ClasseCompraId = c.ClasseCompraId,
                ClasseCompra = c.ClasseCompra,
                QtdParcela = c.QtdParcela,
                ParcelasPagas = c.ParcelasPagas,
                DataCompra = c.DataCompra
            })
            .ToList();

        return View(listaCompras);
    }

    public IActionResult Create(int id)
    {
        ViewBag.ClassesCompra = _context.ClassesCompra
            .Select(c => new ClasseCompraViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            })
            .ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CompraViewModel compraViewModel)
    {

        Console.WriteLine($"Valor recebido no controller: {compraViewModel.Valor}");

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(compraViewModel);
        }

        var compra = new Compra()
        {
            Descricao = compraViewModel.Descricao,
            ClasseCompraId = compraViewModel.ClasseCompraId,
            ClasseCompra = compraViewModel.ClasseCompra,
            Valor = compraViewModel.Valor,
            QtdParcela = compraViewModel.QtdParcela,
            ParcelasPagas = compraViewModel.ParcelasPagas,
            DataCompra = compraViewModel.DataCompra

        };

        _context.Compras.Add(compra);
        _context.SaveChanges();

        return RedirectToAction(nameof(List));

    }

    [HttpGet]
    public IActionResult Edit(int id)
    {

        var compra = _context.Compras
            .Include(c => c.ClasseCompra)
            .FirstOrDefault(c => c.Id == id);

        ViewBag.ClassesCompra = _context.ClassesCompra
            .Select(c => new ClasseCompraViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            })
            .ToList();

        var compraViewModel = new CompraViewModel()
        {
            Id = compra.Id,
            Descricao = compra.Descricao,
            Valor = compra.Valor,
            ClasseCompraId = compra.ClasseCompraId,
            ClasseCompra = compra.ClasseCompra,
            QtdParcela = compra.QtdParcela,
            ParcelasPagas = compra.ParcelasPagas,
            DataCompra = compra.DataCompra
        };


        return View(compraViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CompraViewModel compraViewModel)
    {

        if (!ModelState.IsValid)
        {
            return View(compraViewModel);
        }

        var compra = new Compra()
        {
            Id = compraViewModel.Id,
            Descricao = compraViewModel.Descricao,
            Valor = compraViewModel.Valor,
            ClasseCompraId = compraViewModel.ClasseCompraId,
            ClasseCompra = compraViewModel.ClasseCompra,
            QtdParcela = compraViewModel.QtdParcela,
            ParcelasPagas = compraViewModel.ParcelasPagas,
            DataCompra = compraViewModel.DataCompra
        };


        _context.Compras.Update(compra);
        _context.SaveChanges();

        return RedirectToAction(nameof(List));

    }

    public IActionResult Delete(int id)
    {

        var compra = _context.Compras.Find(id);

        _context.Compras.Remove(compra);
        _context.SaveChanges();

        return RedirectToAction(nameof(List));

    }

}