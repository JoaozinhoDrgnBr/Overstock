using Overstock;
using Overstock.Services;

public class Program
{
    public static void Main()
    {
        Util util = new Util();
        Console.WriteLine("Bem Vindo ao Overstock!");
        util.enterClear();
        
        bool flagMenu = false;
        
        while (flagMenu != true)
        {
            switch (menu())
            {
                case 1:
                    GerenciadorProdutos gerenciadorProdutos = new GerenciadorProdutos();
                    gerenciadorProdutos.MenuProduto();
                    break;
                case 2:
                    GerenciadorCategorias gerenciadorCategorias = new GerenciadorCategorias();
                    gerenciadorCategorias.MenuCategoria();
                    break;
                case 3:
                    GerenciadorVendas gerenciadorVendas = new GerenciadorVendas();
                    gerenciadorVendas.MenuVenda();
                    break;
                case 4:
                    GerenciadorCompras gerenciadorCompras = new GerenciadorCompras();
                    gerenciadorCompras.MenuCompra();
                    break;
                case 0:
                    flagMenu = true;
                    break;
            }
        }
    }
    
    public static int menu()
    {
        Console.WriteLine("Digite a opção que desejas:");
        Console.WriteLine("1 - Produtos");
        Console.WriteLine("2 - Categorias");
        Console.WriteLine("3 - Vendas");
        Console.WriteLine("4 - Compras");
        Console.WriteLine("0 - Sair");
        int opt = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        return opt;
    }
}