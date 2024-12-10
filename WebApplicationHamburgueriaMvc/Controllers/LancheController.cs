using Microsoft.AspNetCore.Mvc;
using WebApplicationHamburgueriaMvc.Models;
using WebApplicationHamburgueriaMvc.Repositories.Interfaces;
using WebApplicationHamburgueriaMvc.ViewModels;

namespace WebApplicationHamburgueriaMvc.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches = null;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(lanche => lanche.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(lanche => lanche.Categoria.CategoriaNome.Equals("Normal")).OrderBy(lanche => lanche.Nome);
                    categoriaAtual = "Normal";
                }
                else if (string.Equals("Natural", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(lanche => lanche.Categoria.CategoriaNome.Equals("Natural")).OrderBy(lanche => lanche.Nome);
                    categoriaAtual = "Natural";
                }
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };

            return View(lanchesListViewModel);
        }
    }
}
