namespace Overstock.Models;

public class VendaProduto
{
    public int VendaId { get; set; }
    public Venda Venda { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public VendaProduto(int vendaId, Venda venda, int produtoId, Produto produto, int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentException("ERRO: Informe uma quantidade válida de produtos");
        }

        VendaId = vendaId;
        Venda = venda;
        ProdutoId = produtoId;
        Produto = produto;
        Quantidade = quantidade;
    }

    public VendaProduto()
    {
        
    }
}