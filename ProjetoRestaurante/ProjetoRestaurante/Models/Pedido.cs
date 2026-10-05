namespace ProjetoRestaurante.Models
{
    public class Pedido
    {
        private int id;
        private string cliente;
        private Item[] itens;

        public Pedido(int id, string cliente)
        {
            this.id = id;
            this.cliente = cliente;
            this.itens = new Item[10];
        }

        public int GetId()
        {
            return id;
        }

        public string GetCliente()
        {
            return cliente;
        }

        public bool AdicionarItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                {
                    itens[i] = item;
                    return true;
                }
            }

            return false;
        }

        public bool RemoverItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].GetId() == item.GetId())
                {
                    itens[i] = null;
                    return true;
                }
            }

            return false;
        }

        public double CalcularTotal()
        {
            double total = 0;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    total += itens[i].GetPreco();
                }
            }

            return total;
        }

        public string DadosDoPedido()
        {
            string dados = "";
            dados += "ID: " + id + "\n";
            dados += "Cliente: " + cliente + "\n";
            dados += "Itens:\n";

            bool possuiItem = false;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    dados += "  " + itens[i].ToString() + "\n";
                    possuiItem = true;
                }
            }

            if (!possuiItem)
            {
                dados += "  Nenhum item adicionado.\n";
            }

            dados += "Valor total: R$ " + CalcularTotal().ToString("F2");

            return dados;
        }

        public Item BuscarItem(int id)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].GetId() == id)
                {
                    return itens[i];
                }
            }

            return null;
        }
    }
}
