namespace Overstock.Models;

public class VendaProduto
{
    public int VendaId { get; set; }
    public Venda Venda { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public VendaProduto(int vendaId, int produtoId, int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentException("ERRO: Informe uma quantidade válida de produtos");
        }

        VendaId = vendaId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
    }

    public VendaProduto()
    {
        
    }
}