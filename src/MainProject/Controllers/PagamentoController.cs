using MainProject.Data;
using MainProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Controllers;

public class PagamentoController : Controller
{

    private readonly ApplicationContext _context;

    public PagamentoController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult List(int id)
    {
        var listaPagamentos = _context.Pagamentos
            .Include(c => c.TipoPagamento)
            .Where(c => c.CompraId == id)
            .ToList();

        var enumerablePagamento = listaPagamentos.Select(p => new PagamentoViewModel
        {
            Id = p.Id,
            CompraId = p.CompraId,
            Valor = p.Valor,
            NumeroParcela = p.NumeroParcela,
            DataPagamento = p.DataPagamento,
            TipoPagamento = p.TipoPagamento
        });

        var listaPagamentosViewModel = new ListaPagamentosViewModel
        {
            CompraId = id,
            Pagamentos = enumerablePagamento,
        };


        return View(listaPagamentosViewModel);
    }

    public IActionResult Create(int id)
    {
        ViewBag.TiposPagamento = _context.TiposPagamento
            .Select(c => new TipoPagamentoViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            })
            .ToList();

        var pagamentoViewModel = new PagamentoViewModel
        {
            CompraId = id
        };

        return View(pagamentoViewModel);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PagamentoViewModel pagamentoViewModel)
    {
        if (!ModelState.IsValid)
        {            
            return View(pagamentoViewModel);
        }

        var compra = _context.Compras.FirstOrDefault(c => c.Id == pagamentoViewModel.CompraId);

        var pagamento = new Pagamento()
        {
            Valor = pagamentoViewModel.Valor,
            TipoPagamentoId = pagamentoViewModel.TipoPagamentoId,
            NumeroParcela = pagamentoViewModel.NumeroParcela,
            DataPagamento = pagamentoViewModel.DataPagamento,
            CompraId = pagamentoViewModel.CompraId
        };

        compra.Pagamentos.Add(pagamento);

        _context.Compras.Update(compra);
        _context.SaveChanges();

        return RedirectToAction("List", new { id = pagamentoViewModel.CompraId });

    }

    [HttpGet]
    public IActionResult Edit(int id)
    {

        var pagamento = _context.Pagamentos            
            .FirstOrDefault(c => c.Id == id);

        ViewBag.TiposPagamento = _context.TiposPagamento
            .Select(c => new TipoPagamentoViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            })
            .ToList();

        var pagamentoViewModel = new PagamentoViewModel()
        {
            Id = pagamento.Id,
            Valor = pagamento.Valor,
            TipoPagamentoId = pagamento.TipoPagamentoId,
            DataPagamento = pagamento.DataPagamento,
            NumeroParcela = pagamento.NumeroParcela,
            CompraId = pagamento.CompraId
        };


        return View(pagamentoViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(PagamentoViewModel pagamentoViewModel)
    {

        if (!ModelState.IsValid)
        {
            return View(pagamentoViewModel);
        }

        var pagamento = new Pagamento()
        {
            Id = pagamentoViewModel.Id,            
            Valor = pagamentoViewModel.Valor,
            TipoPagamentoId = pagamentoViewModel.TipoPagamentoId,
            DataPagamento = pagamentoViewModel.DataPagamento,
            NumeroParcela = pagamentoViewModel.NumeroParcela,
            CompraId = pagamentoViewModel.CompraId
        };


        _context.Pagamentos.Update(pagamento);
        _context.SaveChanges();

        return RedirectToAction("List", new { id = pagamentoViewModel.CompraId });


    }

    public IActionResult Delete(int id)
    {

        var pagamento = _context.Pagamentos.Find(id);

        _context.Pagamentos.Remove(pagamento);
        _context.SaveChanges();

        return RedirectToAction("List", new { id = pagamento.CompraId });

    }

}
