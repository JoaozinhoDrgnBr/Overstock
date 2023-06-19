using Overstock.Controller;
using ConsoleTables;
using MySqlX.XDevAPI.Relational;
using Overstock.Models;

namespace Overstock.UserInterfaces;

public class UICompra
{
    public void MenuCompra()
    {
        Util util = new Util();
        bool flagMenu = false;

        while (flagMenu != true)
        {
            Console.Clear();
            switch (Opcao())
            {
                case 1:
                    adicionarCompra();
                    break;
                case 2:
                    adicionarItemCompra();
                    break;
                case 3:
                    removerItemCompra();
                    break;
                case 4:
                    confirmarCompra();
                    break;
                case 5:
                    atualizarCompra();
                    break;
                case 6:
                    visualizarCompras();
                    break;
                case 7:
                    deletarCompra();
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
        Console.WriteLine("1 - Adicionar compra");
        Console.WriteLine("2 - Adicionar item a compra");
        Console.WriteLine("3 - Remover item da compra");
        Console.WriteLine("4 - Confirmar compra");
        Console.WriteLine("5 - Atualizar dados da compra");
        Console.WriteLine("6 - Visualizar compras");
        Console.WriteLine("7 - Deletar compra");
        Console.WriteLine("0 - Sair");
        int opt = Convert.ToInt32(Console.ReadLine());
        return opt;
    }

    public void adicionarCompra()
    {
        Console.Clear();

        CCompra controller = new CCompra();
        CCompraProduto controllerComProd = new CCompraProduto();
        CProduto controllerProduto = new CProduto();
        
        Console.WriteLine("Informe o nome do fornecedor");
        string fornecedor = Console.ReadLine();
        
        Console.WriteLine("Informe a data que a compra foi realizada");
        string data = Console.ReadLine();
        
        Console.WriteLine("Informe o preco da compra");
        double preco = Convert.ToDouble(Console.ReadLine());

        var compra = new Compra(null, fornecedor, data, preco);
        
        controller.Inserir(compra);
    }

    public void adicionarItemCompra()
    {
        
    }

    public void removerItemCompra()
    {
        
    }

    public void confirmarCompra()
    {
        
    }

    public void atualizarCompra()
    {
        
    }

    public void visualizarCompras()
    {
        Console.Clear();

        CCompra controller = new CCompra();
        CProduto controllerProduto = new CProduto();
        CCompraProduto controllerComProd = new CCompraProduto();
        List<Compra> compras = controller.ObterTodos();
        List<CompraProduto> compraProdutos = controllerComProd.ObterTodos();

        var tabela = new ConsoleTable("Id", "Fornecedor", "Preco total","Data da compra");
        foreach (var fornecedor in compras)
        {
            tabela.AddRow(Convert.ToString(fornecedor.Id), fornecedor.Fornecedor, Convert.ToString(fornecedor.Preco), fornecedor.Data);
        }
        
        tabela.Write();
        
        Console.WriteLine("Deseja ver os itens de qual compra? \n" +
                          "Digite o id da compra desejada ou"+
                          "digite 0 se deseja sair");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }
        if (id == 0)
        {
            return;
        }

        var compra = controller.ObterPorId(id);
        var tabelaProdutos = new ConsoleTable("Id:" + Convert.ToString(compra.Id), "Fornecedor:" + compra.Fornecedor);
        
        
    }

    public void deletarCompra()
    {
        
    }
}