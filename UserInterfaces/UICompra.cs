using Overstock.Controller;
using ConsoleTables;
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
                    visualizarCompraProdutos();
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

        Console.WriteLine("Informe o nome do fornecedor");
        string fornecedor = Console.ReadLine();
        
        Console.WriteLine("Informe a data que a compra foi realizada");
        string data = Console.ReadLine();
        
        Console.WriteLine("Informe o preco da compra");
        double preco = Convert.ToDouble(Console.ReadLine());

        var compra = new Compra(null, fornecedor, data, preco, 0);
        
        controller.Inserir(compra);
        
        Console.WriteLine("Compra adicionada!");
    }
    
    public void adicionarItemCompra()
    {
        UIProduto uiProduto = new UIProduto();

        CCompra controller = new CCompra();
        CCompraProduto controllerComProd = new CCompraProduto();
        CProduto controllerProduto = new CProduto();
        
        visualizarCompras();
        
        Console.WriteLine("Informe o id da compra que quer adicionar itens");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }

        var compra = controller.ObterPorId(id);

        if (compra.CompraStatus == 1)
        {
            Console.WriteLine("Compra já foi confirmada, não pode ser alterada");
            return;
        }

        int opcao = 1;

        while (opcao == 1)
        {
            uiProduto.visualizarProdutos();
            Console.WriteLine("Informe o id do produto que deseja adicionar:");
            int idProduto;
            if (int.TryParse(Console.ReadLine(), out idProduto) == false)
            {
                Console.WriteLine("ERRO: id tem que ser um numero inteiro");
                return;
            }

            var produto = controllerProduto.ObterPorId(idProduto);
            
            Console.WriteLine("Informe a quantidade desse produto:");
            int quantidade;
            if (int.TryParse(Console.ReadLine(), out quantidade) == false)
            {
                Console.WriteLine("ERRO: quantidade tem que ser um numero inteiro");
                return;
            }

            CompraProduto compraProduto = new CompraProduto(Convert.ToInt32(compra.Id), Convert.ToInt32(produto.Id), quantidade);
            controllerComProd.Inserir(compraProduto);
            
            Console.WriteLine("Produto adicionado a compra!\n");
            
            Console.WriteLine("Deseja continuar a inserir? \n1.Sim \n2.Não \n(Qualquer opcao invalida voltará ao menu)");
            opcao = Convert.ToInt32(Console.ReadLine());
            if (opcao != 1)
            {
                return;
            }
        }
        
    }

    public void removerItemCompra()
    {

        UIProduto uiProduto = new UIProduto();

        CCompra controller = new CCompra();
        CCompraProduto controllerComProd = new CCompraProduto();
        CProduto controllerProduto = new CProduto();
        List<CompraProduto> compraProdutos = controllerComProd.ObterTodos();
        
        visualizarCompras();
        
        Console.WriteLine("Informe o id da compra que quer remover itens");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }

        var compra = controller.ObterPorId(id);

        if (compra.CompraStatus == 1)
        {
            Console.WriteLine("Compra já foi confirmada, não pode ser alterada");
            return;
        }

        int cont = 0;
        
        Console.WriteLine("Id: " + compra.Id +" Fornecedor: " + compra.Fornecedor, " Data: " + compra.Data + " Preco: " + compra.Preco);
        var tabelaProdutos = new ConsoleTable(" " ,"Produto", "Quantidade");
        foreach(var CompraId in compraProdutos)
        {
            if (compra.Id == CompraId.CompraId)
            {
                cont++;
                var produto = controllerProduto.ObterPorId(CompraId.ProdutoId);
                tabelaProdutos.AddRow(cont ,produto.Nome, Convert.ToString(CompraId.Quantidade));
            }   
        }

        tabelaProdutos.Write();

        Console.WriteLine("Informe o número do produto que deseja remover");
        int index;
        if (int.TryParse(Console.ReadLine(), out index) == false)
        {
            Console.WriteLine("ERRO: numero informado incorretamente");
            return;
        }
        
        cont = 1;
        foreach (var CompraId in compraProdutos)
        {
            if (cont == index)
            {
                controllerComProd.Excluir(CompraId);
            }

            cont++;
        }
    }

    public void confirmarCompra()
    {
        CCompra controller = new CCompra();
        CProduto controllerProduto = new CProduto();
        CCompraProduto controllerComProd = new CCompraProduto();
        
        List<CompraProduto> compraProdutos = controllerComProd.ObterTodos();
        
        visualizarCompras();
        
        Console.WriteLine("Id da compra que deseja confirmar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }
        
        var compra = controller.ObterPorId(id);

        if (compra.CompraStatus == 1)
        {
            Console.WriteLine("Compra já foi confirmada, não pode ser alterada");
            return;
        }

        foreach (var ProdutoId in compraProdutos)
        {
            if (compra.Id == ProdutoId.CompraId)
            {
                var produto = controllerProduto.ObterPorId(ProdutoId.ProdutoId);
                controllerProduto.Atualizar(new Produto(produto.Id, produto.Nome, produto.Descricao, produto.CategoriaId, produto.Quantidade + ProdutoId.Quantidade, produto.Preco_unidade));   
            }
        }

        Compra compraConfirmada = new Compra(compra.Id, compra.Fornecedor, compra.Data, compra.Preco, 1);
        controller.Atualizar(compraConfirmada);
        
        Console.WriteLine("Compra confirmada!");
        
    }

    public void atualizarCompra()
    {
        Console.Clear();
        
        CCompra controller = new CCompra();
        
        visualizarCompras();
        
        Console.WriteLine("Id da compra que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }
        
        Console.WriteLine("Informe o fornecedor atualizado da compra:");
        string fornecedor = Console.ReadLine();
        
        Console.WriteLine("Informe a data atualizada da compra:");
        string data = Console.ReadLine();
        
        Console.WriteLine("Informe o preco atualizado da compra:");
        double preco = Convert.ToDouble(Console.ReadLine());

        var compra = new Compra(id, fornecedor, data, preco, 0);
        controller.Atualizar(compra);
    }

    public void visualizarCompras()
    {
        Console.Clear();
        
        CCompra controller = new CCompra();
        List<Compra> compras = controller.ObterTodos();

        var tabela = new ConsoleTable("Id", "Fornecedor", "Preco total","Data da compra");
        foreach (var fornecedor in compras)
        {
            tabela.AddRow(Convert.ToString(fornecedor.Id), fornecedor.Fornecedor, Convert.ToString(fornecedor.Preco), fornecedor.Data);
        }
        
        tabela.Write();
    }
    public void visualizarCompraProdutos()
    {

        CCompra controller = new CCompra();
        CProduto controllerProduto = new CProduto();
        CCompraProduto controllerComProd = new CCompraProduto();
        
        List<CompraProduto> compraProdutos = controllerComProd.ObterTodos();

        visualizarCompras();
        
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

        int cont = 0;
        
        Console.WriteLine("Id: " + compra.Id +" Fornecedor: " + compra.Fornecedor, " Data: " + compra.Data + " Preco: " + compra.Preco);
        var tabelaProdutos = new ConsoleTable(" " ,"Produto", "Quantidade");
        foreach(var CompraId in compraProdutos)
        {
            if (compra.Id == CompraId.CompraId)
            {
                cont++;
                var produto = controllerProduto.ObterPorId(CompraId.ProdutoId);
                tabelaProdutos.AddRow(cont ,produto.Nome, Convert.ToString(CompraId.Quantidade));
            }   
        }

        tabelaProdutos.Write();
        
    }

    public void deletarCompra()
    {
        Console.Clear();

        CCompra controller = new CCompra();
        
        visualizarCompras();
        
        Console.WriteLine("Informe o id da compra que deseja remover:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }
        
        try
        {
            var excluir = controller.ObterPorId(id);
            controller.Excluir(excluir);
            Console.WriteLine("Compra excluida!");
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}