using Microsoft.AspNetCore.Mvc;
using WebApplicationHamburgueriaMvc.Areas.Admin.AdminServices;

namespace WebApplicationHamburgueriaMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatoriosVendasService _relatoriosVendasService;

        public AdminRelatorioVendasController(RelatoriosVendasService relatoriosVendasService)
        {
            _relatoriosVendasService = relatoriosVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate,
            DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _relatoriosVendasService.FindByDateAsync(minDate, maxDate);

            return View(result);
        }
    }
}
