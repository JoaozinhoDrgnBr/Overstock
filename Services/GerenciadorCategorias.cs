using ConsoleTables;
using Overstock.Controller;
using Overstock.Interfaces;
using Overstock.Models;

namespace Overstock.Services;

public class GerenciadorCategorias
{
    public void MenuCategoria()
    {
        Util util = new Util();
        bool flagMenu = false;
        
        while (flagMenu != true){
            Console.Clear();
            switch (Opcao())
            {
                case 1:
                    adicionarCategoria();
                    break;
                case 2:
                    atualizarCategoria();
                    break;
                case 3:
                    visualizarCategorias();
                    break;
                case 4:
                    deletarCategoria();
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
        Console.WriteLine("1 - Adicionar categoria");
        Console.WriteLine("2 - Atualizar categoria");
        Console.WriteLine("3 - Visualizar categorias");
        Console.WriteLine("4 - Deletar categoria");
        Console.WriteLine("0 - Sair");
        int opt = Convert.ToInt32(Console.ReadLine());
        return opt;
    }

    public void adicionarCategoria()
    {
        Console.Clear();
        
        CategoriaRepository controller = new CategoriaRepository();
        
        Console.WriteLine("Informe o nome da categoria:");
        string nome = Console.ReadLine();
        
        Console.WriteLine("Informe a descrição da categoria:");
        string descricao = Console.ReadLine();
        
        var categoria = new Categoria(nome, descricao);
        controller.Inserir(categoria);
        
        Console.WriteLine("Categoria inserida!");
    }

    public void atualizarCategoria()
    {
        Console.Clear();
        
        CategoriaRepository controller = new CategoriaRepository();
        
        visualizarCategorias();
        
        Console.WriteLine("Id da categoria que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ERRO: id tem que ser um numero inteiro");
            return;
        }
        
        var atualizar = controller.ObterPorId(id);
        
        Console.WriteLine("Informe o nome atualizado da categoria:");
        string nome = Console.ReadLine();
        
        Console.WriteLine("Informe a nova descricao da categoria:");
        string descricao = Console.ReadLine();

        atualizar.Nome = nome;
        atualizar.Descricao = descricao;
        
        Console.WriteLine("Categoria atualizada!");
    }

    public void visualizarCategorias()
    {
        Console.Clear();
        
        CategoriaRepository controller = new CategoriaRepository();
        List<Categoria> categorias = controller.ObterTodos();
        
        var tabela = new ConsoleTable("Id", "Nome", "Descricao");
        foreach (var nome in categorias)
        {
            tabela.AddRow(Convert.ToString(nome.Id), nome.Nome, nome.Descricao);
        }
        tabela.Write();
    }

    public void deletarCategoria()
    {
        Console.Clear();
        
        CategoriaRepository controller = new CategoriaRepository();
        
        visualizarCategorias();
        
        Console.WriteLine("Id da categoria que deseja excluir:");
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
            Console.WriteLine("Categoria excluida!");
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}