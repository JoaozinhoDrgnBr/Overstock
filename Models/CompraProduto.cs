using System.ComponentModel.DataAnnotations;

namespace Overstock.Models;

public class CompraProduto
{
     public int CompraId { get; set; }
     public Compra Compra { get; set; }
     public int ProdutoId { get; set; }
     public Produto Produto { get; set; }
     public int Quantidade { get; set; }

     public CompraProduto(int compraId, Compra compra, int produtoId, Produto produto, int quantidade)
     {
         if (quantidade <= 0)
         {
             throw new ArgumentException("ERRO: Informe uma quantidade válida de produtos");
         }
         
         CompraId = compraId;
         Compra = compra;
         ProdutoId = produtoId;
         Produto = produto;
         Quantidade = quantidade;
     }

     public CompraProduto()
     {
         
     }
}