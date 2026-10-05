using ProjetoRestaurante.Controllers;
using ProjetoRestaurante.Models;

namespace ProjetoRestaurante.Views
{
    public class MenuView
    {
        private RestauranteController controller;

        public MenuView(RestauranteController controller)
        {
            this.controller = controller;
        }

        public void ExibirMenu()
        {
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("       SISTEMA RESTAURANTE");
                Console.WriteLine("=================================");
                Console.WriteLine("1 - Criar novo pedido");
                Console.WriteLine("2 - Adicionar item ao pedido");
                Console.WriteLine("3 - Remover item do pedido");
                Console.WriteLine("4 - Consultar pedido");
                Console.WriteLine("5 - Cancelar pedido");
                Console.WriteLine("6 - Listar todos os pedidos");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("=================================");
                Console.Write("Escolha uma opção: ");

                int.TryParse(Console.ReadLine(), out opcao);

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        CriarPedido();
                        break;

                    case 2:
                        AdicionarItem();
                        break;

                    case 3:
                        RemoverItem();
                        break;

                    case 4:
                        ConsultarPedido();
                        break;

                    case 5:
                        CancelarPedido();
                        break;

                    case 6:
                        ListarPedidos();
                        break;

                    case 0:
                        Console.WriteLine("Sistema encerrado.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcao != 0);
        }

        private void CriarPedido()
        {
            Console.WriteLine("=== NOVO PEDIDO ===");
            Console.Write("Nome do cliente: ");
            string cliente = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cliente))
            {
                Console.WriteLine("Nome do cliente inválido.");
                return;
            }

            bool resultado = controller.CriarPedido(cliente);

            if (resultado)
            {
                Console.WriteLine("Pedido criado com sucesso.");
                MostrarUltimoPedidoCriado();
            }
            else
            {
                Console.WriteLine("Não foi possível criar o pedido.");
                Console.WriteLine("O limite de 50 pedidos foi atingido.");
            }
        }

        private void MostrarUltimoPedidoCriado()
        {
            Pedido[] pedidos = controller.ListarPedidos();
            Pedido ultimo = null;

            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null)
                {
                    if (ultimo == null || pedidos[i].GetId() > ultimo.GetId())
                    {
                        ultimo = pedidos[i];
                    }
                }
            }

            if (ultimo != null)
            {
                Console.WriteLine("ID: " + ultimo.GetId());
                Console.WriteLine("Cliente: " + ultimo.GetCliente());
            }
        }

        private void AdicionarItem()
        {
            Console.WriteLine("=== ADICIONAR ITEM ===");

            Console.Write("ID do pedido: ");
            int idPedido = LerInteiro();

            Pedido pedido = controller.BuscarPedido(idPedido);

            if (pedido == null)
            {
                Console.WriteLine("Pedido não encontrado.");
                return;
            }

            Console.Write("ID do item: ");
            int idItem = LerInteiro();

            Console.Write("Descrição do item: ");
            string descricao = Console.ReadLine();

            Console.Write("Preço do item: R$ ");
            double preco = LerDouble();

            Item item = new Item(idItem, descricao, preco);

            if (controller.AdicionarItem(idPedido, item))
            {
                Console.WriteLine("Item adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar o item.");
                Console.WriteLine("Verifique se o pedido possui espaço para mais itens.");
            }
        }

        private void RemoverItem()
        {
            Console.WriteLine("=== REMOVER ITEM ===");

            Console.Write("ID do pedido: ");
            int idPedido = LerInteiro();

            Console.Write("ID do item: ");
            int idItem = LerInteiro();

            if (controller.RemoverItem(idPedido, idItem))
            {
                Console.WriteLine("Item removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Não foi possível remover o item.");
                Console.WriteLine("Verifique o ID do pedido e do item.");
            }
        }

        private void ConsultarPedido()
        {
            Console.WriteLine("=== CONSULTAR PEDIDO ===");

            Console.Write("ID do pedido: ");
            int id = LerInteiro();

            Pedido pedido = controller.BuscarPedido(id);

            if (pedido == null)
            {
                Console.WriteLine("Pedido não encontrado.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine(pedido.DadosDoPedido());
        }

        private void CancelarPedido()
        {
            Console.WriteLine("=== CANCELAR PEDIDO ===");

            Console.Write("ID do pedido: ");
            int id = LerInteiro();

            if (controller.CancelarPedido(id))
            {
                Console.WriteLine("Pedido cancelado com sucesso.");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }

        private void ListarPedidos()
        {
            Console.WriteLine("=== PEDIDOS DO DIA ===");

            Pedido[] pedidos = controller.ListarPedidos();
            bool encontrou = false;

            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null)
                {
                    encontrou = true;

                    Console.WriteLine(
                        "Pedido " + pedidos[i].GetId() +
                        " - Cliente: " + pedidos[i].GetCliente() +
                        " - Total: R$ " + pedidos[i].CalcularTotal().ToString("F2")
                    );
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum pedido cadastrado.");
            }

            Console.WriteLine();
            Console.WriteLine("Soma geral do dia: R$ " +
                controller.CalcularTotalDoDia().ToString("F2"));
        }

        private int LerInteiro()
        {
            int valor;

            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Digite um número válido: ");
            }

            return valor;
        }

        private double LerDouble()
        {
            double valor;

            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Digite um preço válido: ");
            }

            return valor;
        }
    }
}
