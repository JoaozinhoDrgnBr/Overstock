using System.ComponentModel.DataAnnotations;

namespace Overstock.Models;

public class Compra
{
    [Key] public int? Id {get; set;}
    public string Fornecedor {get; set;}
    public string Data {get; set;}
    public double Preco {get; set;}

    public Compra(int? id, string fornecedor, string data, double preco)
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
    }

    public Compra()
    {
        
    }
}