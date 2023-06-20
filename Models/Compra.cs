using System.ComponentModel.DataAnnotations;

namespace Overstock.Models;

public class Compra
{
    [Key] public int? Id {get; set;}
    public string Fornecedor {get; set;}
    public string Data {get; set;}
    public double Preco {get; set;}
    
    public int CompraStatus { get; set; }
    public ICollection<CompraProduto> CompraProdutos { get; set; }
    
    public Compra(int? id, string fornecedor, string data, double preco, int compraStatus)
    {
        if (String.IsNullOrEmpty(fornecedor))
        {
            throw new ArgumentException("ERRO: Fornecedor deve ser informado");
        }
        if (String.IsNullOrEmpty(data))
        {
            throw new ArgumentException("ERRO: Data deve ser informada");
        }
        if (preco <= 0)
        {
            throw new ArgumentException("ERRO: Preco deve ser informado corretamente");
        }

        Id = id;
        Fornecedor = fornecedor;
        Data = data;
        Preco = preco;
        CompraStatus = compraStatus;
    }

    public Compra()
    {
        
    }
}