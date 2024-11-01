using WebApplicationHamburgueriaMvc.Context;
using WebApplicationHamburgueriaMvc.Models;
using WebApplicationHamburgueriaMvc.Repositories.Interfaces;

namespace WebApplicationHamburgueriaMvc.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
