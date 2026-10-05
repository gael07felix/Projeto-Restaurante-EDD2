namespace ProjetoRestaurante.Models
{
    public class Restaurante
    {
        private int proxPedido;
        private Pedido[] pedidos;

        public Restaurante()
        {
            proxPedido = 1;
            pedidos = new Pedido[50];
        }

        public bool NovoPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == null)
                {
                    pedidos[i] = pedido;
                    proxPedido++;
                    return true;
                }
            }

            return false;
        }

        public Pedido BuscarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                return null;
            }

            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].GetId() == pedido.GetId())
                {
                    return pedidos[i];
                }
            }

            return null;
        }

        public Pedido BuscarPedidoPorId(int id)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].GetId() == id)
                {
                    return pedidos[i];
                }
            }

            return null;
        }

        public bool CancelarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                return false;
            }

            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].GetId() == pedido.GetId())
                {
                    pedidos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public int GetProximoPedido()
        {
            return proxPedido;
        }

        public Pedido[] GetPedidos()
        {
            return pedidos;
        }
    }
}
