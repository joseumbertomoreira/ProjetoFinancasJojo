using MainProject.Data;
using MainProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MainProject.Models;

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
            .Where(c => c.CompraId == id)
            .ToList();

        var enumerablePagamento = listaPagamentos.Select(p => new PagamentoViewModel
        {
            Id = p.Id,
            CompraId = p.CompraId,
            Valor = p.Valor,
            DataPagamento = p.DataPagamento
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

        return View();

    }
}
