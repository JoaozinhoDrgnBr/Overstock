using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Overstock.Models;

public class Produto
{
    [Key] public int? Id {get; set;}
    public string Nome {get; set;}
    public string Descricao {get; set;}
    public Categoria Categoria {get; set;}
    public int CategoriaId { get; set; }
    public int Quantidade {get; set;}
    public double Preco_unidade {get; set;}

    public ICollection<CompraProduto> CompraProdutos { get; set; }
    
    public ICollection<VendaProduto> VendaProdutos { get; set; }

    public Produto(int? id, string nome, string descricao, int categoriaId, int quantidade, double precoUnidade)
    {
        if (String.IsNullOrEmpty(nome))
        {
            throw new ArgumentException("ERRO: Nome do produto deve ser informado");
        }
        if (quantidade < 0)
        {
            throw new ArgumentException("ERRO: Informe uma quantidade válida de produtos");
        }
        if (precoUnidade <= 0)
        {
            throw new ArgumentException("ERRO: Informe um preço válido para o produto");
        }

        Id = id;
        Nome = nome;
        Descricao = descricao;
        CategoriaId = categoriaId;
        Quantidade = quantidade;
        Preco_unidade = precoUnidade;
    }

    public Produto()
    {
        
    }
}