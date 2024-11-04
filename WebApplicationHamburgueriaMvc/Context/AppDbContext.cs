using Microsoft.EntityFrameworkCore;
using WebApplicationHamburgueriaMvc.Models;

namespace WebApplicationHamburgueriaMvc.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {    
            //Carrega as informações necessárias para configurar o DbContext
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    }
}
