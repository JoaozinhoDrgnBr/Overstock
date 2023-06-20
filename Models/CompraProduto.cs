using System.ComponentModel.DataAnnotations;

namespace Overstock.Models;

public class CompraProduto
{
     public int CompraId { get; set; }
     public Compra Compra { get; set; }
     public int ProdutoId { get; set; }
     public Produto Produto { get; set; }
     public int Quantidade { get; set; }

     public CompraProduto(int compraId, int produtoId, int quantidade)
     {
         if (quantidade <= 0)
         {
             throw new ArgumentException("ERRO: Informe uma quantidade válida de produtos");
         }
         
         CompraId = compraId;
         ProdutoId = produtoId;
         Quantidade = quantidade;
     }

     public CompraProduto()
     {
         
     }
}