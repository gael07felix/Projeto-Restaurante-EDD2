using ProjetoRestaurante.Controllers;
using ProjetoRestaurante.Views;

namespace ProjetoRestaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestauranteController controller = new RestauranteController();
            MenuView menu = new MenuView(controller);

            menu.ExibirMenu();
        }
    }
}
