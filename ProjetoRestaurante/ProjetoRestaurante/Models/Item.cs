namespace ProjetoRestaurante.Models
{
    public class Item
    {
        private int id;
        private string descricao;
        private double preco;

        public Item(int id, string descricao, double preco)
        {
            this.id = id;
            this.descricao = descricao;
            this.preco = preco;
        }

        public int GetId()
        {
            return id;
        }

        public string GetDescricao()
        {
            return descricao;
        }

        public double GetPreco()
        {
            return preco;
        }

        public override string ToString()
        {
            return id + " - " + descricao + " - R$ " + preco.ToString("F2");
        }
    }
}
