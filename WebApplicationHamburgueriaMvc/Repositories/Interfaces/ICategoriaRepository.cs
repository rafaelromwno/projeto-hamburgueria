using WebApplicationHamburgueriaMvc.Models;

namespace WebApplicationHamburgueriaMvc.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
