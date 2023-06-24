using ConsoleTables;
using Overstock.Controller;
using Overstock.Models;

namespace Overstock.Services;

public class GerenciadorProdutos
{
    public void MenuProduto()
    {
        Util util = new Util();
        bool flagMenu = false;
        
        while (flagMenu != true){
            switch (Opcao())
            {
                case 1:
                    adicionarProduto();
                    break;
                case 2:
                    atualizarProduto();
                    break;
                case 3:
                    visualizarProdutos();
                    break;
                case 4:
                    deletarProduto();
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
        Console.WriteLine("1 - Adicionar produto");
        Console.WriteLine("2 - Atualizar produto");
        Console.WriteLine("3 - Visualizar produtos");
        Console.WriteLine("4 - Deletar produto");
        Console.WriteLine("0 - Sair");
        int opt = Convert.ToInt32(Console.ReadLine());
        return opt;
    }

    public void adicionarProduto()
    {
        Console.Clear();
        
        ProdutoRepository controller = new ProdutoRepository();
        CategoriaRepository controllerCategoriaRepository = new CategoriaRepository();
        GerenciadorCategorias gerenciadorCategorias = new GerenciadorCategorias();
        
        Console.WriteLine("Informe o nome do produto:");
        string nome = Console.ReadLine();
        
        Console.WriteLine("Informe a descrição do produto:");
        string descricao = Console.ReadLine();

        gerenciadorCategorias.visualizarCategorias();
        
        Console.WriteLine("Id da categoria que deseja atrelar ao produto:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }

        var categoria = controllerCategoriaRepository.ObterPorId(id);
        
        Console.WriteLine("Informe a quantidade de produtos em estoque:");
        int quantidade = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Informe o preco unitario do produto:");
        double precoUnidade = Convert.ToDouble(Console.ReadLine());
        
        var produto = new Produto(null, nome, descricao, categoria.Id, quantidade, precoUnidade);
        controller.Inserir(produto);
        
        Console.WriteLine("Produto inserido!");
    }

    public void atualizarProduto()
    {
        Console.Clear();
        
        ProdutoRepository controller = new ProdutoRepository();
        CategoriaRepository controllerCategoriaRepository = new CategoriaRepository();
        GerenciadorCategorias gerenciadorCategorias = new GerenciadorCategorias();
        
        visualizarProdutos();
        
        Console.WriteLine("Id do produto que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }

        Console.WriteLine("Informe o nome atualizado do produto:");
        string nome = Console.ReadLine();
        
        Console.WriteLine("Informe a descricao atualizada do produto:");
        string descricao = Console.ReadLine();
        
        gerenciadorCategorias.visualizarCategorias();
        
        Console.WriteLine("Id da categoria atualizada do produto:");
        int idcat;
        if (int.TryParse(Console.ReadLine(), out idcat) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }

        var categoria = controllerCategoriaRepository.ObterPorId(idcat);

        Console.WriteLine("Informe a quantidade de produtos em estoque atualizada");
        int quantidade = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Informe o preco unitario atualizado do produto:");
        double precoUnidade = Convert.ToDouble(Console.ReadLine());

        var produto = new Produto(id, nome, descricao, categoria.Id, quantidade, precoUnidade);
        controller.Atualizar(produto);
    }

    public void visualizarProdutos()
    {
        Console.Clear();
        
        ProdutoRepository controller = new ProdutoRepository();
        CategoriaRepository controllerCategoriaRepository = new CategoriaRepository();
        List<Produto> produtos = controller.ObterTodos();
        
        var tabela = new ConsoleTable("Id", "Nome", "Descricao", "Categoria", "Quantidade", "Preco unitario");
        foreach (var nome in produtos)
        {
            var categoria = controllerCategoriaRepository.ObterPorId(nome.CategoriaId);
            tabela.AddRow(nome.Id, nome.Nome, nome.Descricao, categoria.Nome, nome.Quantidade, nome.Preco_unidade);
        }
        tabela.Write();
    }

    public void deletarProduto()
    {
        Console.Clear();
        
        ProdutoRepository controller = new ProdutoRepository();
        
        visualizarProdutos();
        
        Console.WriteLine("Id do produto que deseja excluir:");
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
            Console.WriteLine("Produto excluido!");
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
}