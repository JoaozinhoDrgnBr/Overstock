using Overstock.Controller;
using ConsoleTables;
using Overstock.Models;

namespace Overstock.Services;

public class GerenciadorVendas
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
                    adicionarItemVenda();
                    break;
                case 3:
                    removerItemVenda();
                    break;
                case 4:
                    confirmarVenda();
                    break;
                case 5:
                    atualizarVenda();
                    break;
                case 6:
                    visualizarVendaProdutos();
                    break;
                case 7:
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
        Console.WriteLine("2 - Adicionar item a venda");
        Console.WriteLine("3 - Remover item da venda");
        Console.WriteLine("4 - Confirmar venda");
        Console.WriteLine("5 - Atualizar dados da venda");
        Console.WriteLine("6 - Visualizar vendas");
        Console.WriteLine("7 - Deletar venda");
        Console.WriteLine("0 - Sair");
        int opt = Convert.ToInt32(Console.ReadLine());
        return opt;
    }

    public void adicionarVenda()
    {
        Console.Clear();

        VendaRepository controller = new VendaRepository();

        Console.WriteLine("Informe o nome do cliente");
        string cliente = Console.ReadLine();
        
        Console.WriteLine("Informe a data que a venda foi realizada");
        string data = Console.ReadLine();

        var venda = new Venda(null, cliente, data, 0, 0);
        
        controller.Inserir(venda);
        
        Console.WriteLine("Venda adicionada!");
    }
    
    public void adicionarItemVenda()
    {
        GerenciadorProdutos gerenciadorProdutos = new GerenciadorProdutos();

        VendaRepository controller = new VendaRepository();
        VendaProdutoRepository controllerVenProd = new VendaProdutoRepository();
        ProdutoRepository controllerProdutoRepository = new ProdutoRepository();
        
        visualizarVendas();
        
        Console.WriteLine("Informe o id da venda que quer adicionar itens");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }

        var venda = controller.ObterPorId(id);

        if (venda.VendaStatus == 1)
        {
            Console.WriteLine("Venda já foi confirmada, não pode ser alterada");
            return;
        }

        int opcao = 1;

        while (opcao == 1)
        {
            gerenciadorProdutos.visualizarProdutos();
            Console.WriteLine("Informe o id do produto que deseja adicionar:");
            int idProduto;
            if (int.TryParse(Console.ReadLine(), out idProduto) == false)
            {
                Console.WriteLine("ERRO: id tem que ser um numero inteiro");
                return;
            }

            var produto = controllerProdutoRepository.ObterPorId(idProduto);
            
            Console.WriteLine("Informe a quantidade desse produto:");
            int quantidade;
            if (int.TryParse(Console.ReadLine(), out quantidade) == false)
            {
                Console.WriteLine("ERRO: quantidade tem que ser um numero inteiro");
                return;
            }

            if (produto.Quantidade < quantidade)
            {
                Console.WriteLine("Não há produtos suficientes em estoque, retornando ao menu");
                return;
            }
            
            VendaProduto vendaProduto = new VendaProduto(Convert.ToInt32(venda.Id), Convert.ToInt32(produto.Id), quantidade);
            controllerVenProd.Inserir(vendaProduto);

            venda.Preco += produto.Preco_unidade * quantidade;
            controller.Atualizar(venda);
            
            Console.WriteLine("Produto adicionado a venda!\n");
            
            Console.WriteLine("Deseja continuar a inserir? \n1.Sim \n2.Não \n(Qualquer opcao invalida voltará ao menu)");
            opcao = Convert.ToInt32(Console.ReadLine());
            if (opcao != 1)
            {
                return;
            }
        }
        
    }

    public void removerItemVenda()
    {

       
        VendaRepository controller = new VendaRepository();
        VendaProdutoRepository controllerVenProd = new VendaProdutoRepository();
        ProdutoRepository controllerProdutoRepository = new ProdutoRepository();
        List<VendaProduto> vendaProdutos = controllerVenProd.ObterTodos();
        
        visualizarVendas();
        
        Console.WriteLine("Informe o id da venda que quer remover itens");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }

        var venda = controller.ObterPorId(id);

        if (venda.VendaStatus == 1)
        {
            Console.WriteLine("Venda já foi confirmada, não pode ser alterada");
            return;
        }

        int cont = 0;
        
        Console.WriteLine("Id: " + venda.Id +" Cliente: " + venda.Cliente, " Data: " + venda.Data + " Preco: " + venda.Preco);
        var tabelaProdutos = new ConsoleTable(" " ,"Produto", "Quantidade");
        foreach(var VendaId in vendaProdutos)
        {
            if (venda.Id == VendaId.VendaId)
            {
                cont++;
                var produto = controllerProdutoRepository.ObterPorId(VendaId.ProdutoId);
                tabelaProdutos.AddRow(cont ,produto.Nome, Convert.ToString(VendaId.Quantidade));
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
        foreach (var VendaId in vendaProdutos)
        {
            if (cont == index)
            {
                controllerVenProd.Excluir(VendaId);
            }

            cont++;
        }
    }

    public void confirmarVenda()
    {
        VendaRepository controller = new VendaRepository();
        ProdutoRepository controllerProdutoRepository = new ProdutoRepository();
        VendaProdutoRepository controllerVenProd = new VendaProdutoRepository();

        List<VendaProduto> vendaProdutos = controllerVenProd.ObterTodos();

        visualizarVendas();

        Console.WriteLine("Id da venda que deseja confirmar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }

        var venda = controller.ObterPorId(id);

        if (venda.VendaStatus == 1)
        {
            Console.WriteLine("Venda já foi confirmada, não pode ser alterada");
            return;
        }

        foreach (var ProdutoId in vendaProdutos)
        {
            if (venda.Id == ProdutoId.VendaId)
            {
                var produto = controllerProdutoRepository.ObterPorId(ProdutoId.ProdutoId);
                produto.Quantidade -= ProdutoId.Quantidade;
                controllerProdutoRepository.Atualizar(produto);
            }
        }

        venda.VendaStatus = 1;
        controller.Atualizar(venda);

        Console.WriteLine("Compra confirmada!");
    }

    public void atualizarVenda()
    {
        Console.Clear();
        
        VendaRepository controller = new VendaRepository();
        
        visualizarVendas();
        
        Console.WriteLine("Id da venda que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }
        
        Console.WriteLine("Informe o cliente atualizado da venda:");
        string cliente = Console.ReadLine();
        
        Console.WriteLine("Informe a data atualizada da venda:");
        string data = Console.ReadLine();
        
        Console.WriteLine("Informe o preco atualizado da venda:");
        double preco = Convert.ToDouble(Console.ReadLine());

        var venda = new Venda(id, cliente, data, preco, 0);
        controller.Atualizar(venda);
    }

    public void visualizarVendas()
    {
        Console.Clear();

        VendaRepository controller = new VendaRepository();
        List<Venda> vendas = controller.ObterTodos();

        var tabela = new ConsoleTable("Id", "Cliente", "Preco total","Data da venda");
        foreach (var cliente in vendas)
        {
            tabela.AddRow(Convert.ToString(cliente.Id), cliente.Cliente, Convert.ToString(cliente.Preco), cliente.Data);
        }
        
        tabela.Write();
    }
    public void visualizarVendaProdutos()
    {

        VendaRepository controller = new VendaRepository();
        ProdutoRepository controllerProdutoRepository = new ProdutoRepository();
        VendaProdutoRepository controllerVenProd = new VendaProdutoRepository();
        
        List<VendaProduto> vendaProdutos = controllerVenProd.ObterTodos();

        visualizarVendas();
        
        Console.WriteLine("Deseja ver os itens de qual venda? \n" +
                          "Digite o id da venda desejada ou"+
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

        var venda = controller.ObterPorId(id);

        int cont = 0;
        
        Console.WriteLine("Id: " + venda.Id +" Cliente: " + venda.Cliente, " Data: " + venda.Data + " Preco: " + venda.Preco);
        var tabelaProdutos = new ConsoleTable(" " ,"Produto", "Quantidade");
        foreach(var VendaId in vendaProdutos)
        {
            if (venda.Id == VendaId.VendaId)
            {
                cont++;
                var produto = controllerProdutoRepository.ObterPorId(VendaId.ProdutoId);
                tabelaProdutos.AddRow(cont ,produto.Nome, Convert.ToString(VendaId.Quantidade));
            }   
        }

        tabelaProdutos.Write();
        
    }

    public void deletarVenda()
    {
        Console.Clear();

        VendaRepository controller = new VendaRepository();
        
        visualizarVendas();
        
        Console.WriteLine("Informe o id da venda que deseja remover:");
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
            Console.WriteLine("Venda excluida!");
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}