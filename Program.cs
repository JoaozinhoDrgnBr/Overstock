using Overstock.UserInterfaces;
using Overstock.UserInterfaces;

public class Program
{
    public static void Main()
    {
        bool flagMenu = false;

        while (flagMenu != true)
        {
            switch (menu())
            {
                case 1:
                    UIProduto uiProduto = new UIProduto();
                    uiProduto.MenuProduto();
                    break;
                case 2:
                    UICategoria uiCategoria = new UICategoria();
                    uiCategoria.MenuCategoria();
                    break;
                case 3:
                    UIVenda uiVenda = new UIVenda();
                    uiVenda.MenuVenda();
                    break;
                case 4:
                    UICompra uiCompra = new UICompra();
                    uiCompra.MenuCompra();
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