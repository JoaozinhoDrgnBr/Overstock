using System.ComponentModel.DataAnnotations;

namespace Overstock.Models;

    public class Categoria
{
    [Key] public int Id {get; set;}
    public string Nome {get; set;}
    public string Descricao {get; set;}

    public Categoria(string nome, string descricao)
    {
        if (String.IsNullOrEmpty(nome))
        {
            throw new ArgumentException("ERRO: Nome da categoria deve ser informado");
        }
        
        Nome = nome;
        Descricao = descricao;
    }

    public Categoria()
    {
        
    }
}