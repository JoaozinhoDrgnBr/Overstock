namespace Overstock.UserInterfaces;

public class UIVenda
{
    public void MenuVenda()
    {
        Util util = new Util();
        bool flagMenu = false;

        while (flagMenu != true)
        {
            Console.Clear();
            switch (Opcao())
            {
                case 1:
                    adicionarVenda();
                    break;
                case 2:
                    atualizarVenda();
                    break;
                case 3:
                    visualizarVendas();
                    break;
                case 4:
                    deletarVenda();
                    break;
                case 0:
                    flagMenu = true;
                    break;
            }

            util.enterClear();
        }
    }

    public int Opcao()
    {
        Console.WriteLine("Digite a opção que desejas:");
        Console.WriteLine("1 - Adicionar venda");
        Console.WriteLine("2 - Atualizar venda");
        Console.WriteLine("3 - Visualizar vendas");
        Console.WriteLine("4 - Deletar venda");
        Console.WriteLine("0 - Sair");
        int opt = Convert.ToInt32(Console.ReadLine());
        return opt;
    }

    public void adicionarVenda()
    {

    }

    public void atualizarVenda()
    {

    }

    public void visualizarVendas()
    {

    }

    public void deletarVenda()
    {

    }
}