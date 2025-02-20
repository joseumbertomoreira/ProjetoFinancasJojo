using MainProject.Data;
using MainProject.Models;
using MainProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MainProject.Controllers
{
    public class TipoPagamentoController : Controller
    {

        private readonly ApplicationContext _context;

        public TipoPagamentoController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {

            var listaTipoPagamento = _context.TiposPagamento
            .Select(c => new TipoPagamentoViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            })
            .ToList();

            return View(listaTipoPagamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Descricao")] TipoPagamentoViewModel tipoPagamentoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoPagamentoViewModel);
            }

            var tipoPagamento = new TipoPagamento()
            {
                Nome = tipoPagamentoViewModel.Nome,
                Descricao = tipoPagamentoViewModel.Descricao
            };

            _context.TiposPagamento.Add(tipoPagamento);
            _context.SaveChanges();

            return RedirectToAction(nameof(List));

        }

        public IActionResult Edit(int id)
        {

            var tipoPagamento = _context.TiposPagamento.Find(id);

            var tipoPagamentoViewModel = new TipoPagamentoViewModel()
            {
                Id = tipoPagamento.Id,
                Nome = tipoPagamento.Nome,
                Descricao = tipoPagamento.Descricao
            };

            return View(tipoPagamentoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Nome,Descricao")] TipoPagamentoViewModel tipoPagamentoViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(tipoPagamentoViewModel);
            }

            var tipoPagamento = new TipoPagamento()
            {
                Id = tipoPagamentoViewModel.Id,
                Nome = tipoPagamentoViewModel.Nome,
                Descricao = tipoPagamentoViewModel.Descricao
            };


            _context.TiposPagamento.Update(tipoPagamento);
            _context.SaveChanges();

            return RedirectToAction(nameof(List));

        }

        public IActionResult Delete(int id)
        {

            var tipoPagamento = _context.TiposPagamento.Find(id);

            _context.TiposPagamento.Remove(tipoPagamento);
            _context.SaveChanges();

            return RedirectToAction(nameof(List));

        }

    }
}
