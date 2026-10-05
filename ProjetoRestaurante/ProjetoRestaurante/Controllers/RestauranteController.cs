using ProjetoRestaurante.Models;

namespace ProjetoRestaurante.Controllers
{
    public class RestauranteController
    {
        private Restaurante restaurante;

        public RestauranteController()
        {
            restaurante = new Restaurante();
        }

        public bool CriarPedido(string cliente)
        {
            Pedido pedido = new Pedido(restaurante.GetProximoPedido(), cliente);

            return restaurante.NovoPedido(pedido);
        }

        public Pedido BuscarPedido(int id)
        {
            return restaurante.BuscarPedidoPorId(id);
        }

        public bool AdicionarItem(int idPedido, Item item)
        {
            Pedido pedido = restaurante.BuscarPedidoPorId(idPedido);

            if (pedido == null)
            {
                return false;
            }

            return pedido.AdicionarItem(item);
        }

        public bool RemoverItem(int idPedido, int idItem)
        {
            Pedido pedido = restaurante.BuscarPedidoPorId(idPedido);

            if (pedido == null)
            {
                return false;
            }

            Item item = pedido.BuscarItem(idItem);

            if (item == null)
            {
                return false;
            }

            return pedido.RemoverItem(item);
        }

        public bool CancelarPedido(int id)
        {
            Pedido pedido = restaurante.BuscarPedidoPorId(id);

            if (pedido == null)
            {
                return false;
            }

            return restaurante.CancelarPedido(pedido);
        }

        public Pedido[] ListarPedidos()
        {
            return restaurante.GetPedidos();
        }

        public double CalcularTotalDoDia()
        {
            double total = 0;
            Pedido[] pedidos = restaurante.GetPedidos();

            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null)
                {
                    total += pedidos[i].CalcularTotal();
                }
            }

            return total;
        }
    }
}
