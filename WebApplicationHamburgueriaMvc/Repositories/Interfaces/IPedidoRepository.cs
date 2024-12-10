using WebApplicationHamburgueriaMvc.Models;

namespace WebApplicationHamburgueriaMvc.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        public void CriarPedido(Pedido pedido);
    }
}
