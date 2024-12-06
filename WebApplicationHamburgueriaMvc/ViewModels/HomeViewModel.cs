using WebApplicationHamburgueriaMvc.Models;

namespace WebApplicationHamburgueriaMvc.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
