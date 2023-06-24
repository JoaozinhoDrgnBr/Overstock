using System.ComponentModel.DataAnnotations;

namespace Overstock.Models;

public class Venda
{
    [Key] public int? Id {get; set;}
    public string Cliente {get; set;}
    public string Data {get; set;}
    public double Preco {get; set;}
    public int VendaStatus { get; set; }
    
    public ICollection<VendaProduto> VendaProdutos { get; set; }

    public Venda(int? id, string cliente, string data, double preco, int vendaStatus)
    {
        if (String.IsNullOrEmpty(cliente))
        {
            throw new ArgumentException("ERRO: Nome do cliente deve ser informado");
        }
        if (String.IsNullOrEmpty(data))
        {
            throw new ArgumentException("ERRO: Data deve ser inserida corretamente");
        }
        if (preco <= 0)
        {
            throw new ArgumentException("ERRO: Informe um preco válido");
        }

        Id = id;
        Cliente = cliente;
        Data = data;
        Preco = preco;
        VendaStatus = vendaStatus;
    }

    public Venda()
    {
        
    }
}