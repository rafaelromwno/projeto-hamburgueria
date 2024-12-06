using Microsoft.AspNetCore.Mvc;

namespace WebApplicationHamburgueriaMvc.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
