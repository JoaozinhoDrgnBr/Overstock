using Microsoft.EntityFrameworkCore;
using Overstock.Models;

namespace Overstock.Data;

public class OverstockContext : DbContext
{
    
    public DbSet<Produto> Produtos {get; set;}
    public DbSet<Compra> Compras {get; set;}
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Venda> Vendas {get; set;}
    // public DbSet<VendaProduto> VendaProdutos { get; set; }
    // public DbSet<CompraProduto> CompraProdutos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Persist Security Info=False;server=localhost;database=Overstock;uid=root;pwd=";
        optionsBuilder.UseMySQL(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(c => c.Descricao)
                .HasMaxLength(500);
        });
        
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.Descricao)
                .HasMaxLength(500);

            entity.Property(p => p.Quantidade)
                .IsRequired();

            entity.Property(p => p.Preco_unidade)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Fornecedor)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Data)
                .IsRequired();

            entity.Property(c => c.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey((v => v.Id));

            entity.Property(v => v.Cliente)
                .HasMaxLength(155)
                .IsRequired();

            entity.Property(v => v.Data)
                .IsRequired();
            
            entity.Property(c => c.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        });

        modelBuilder.Entity<CompraProduto>(entity =>
        {
            entity.HasKey(cp => new { cp.CompraId, cp.ProdutoId });
        
            entity.HasOne(cp => cp.Compra)
                .WithMany()
                .HasForeignKey(cp => cp.CompraId);
        
            entity.HasOne(cp => cp.Produto)
                .WithMany()
                .HasForeignKey(cp => cp.ProdutoId);
        
            entity.Property(cp => cp.Quantidade)
                .IsRequired();
        });
        
        modelBuilder.Entity<VendaProduto>(entity =>
        {
            entity.HasKey(vp => new { vp.VendaId, vp.ProdutoId });
        
            entity.HasOne(vp => vp.Venda)
                .WithMany()
                .HasForeignKey(vp => vp.VendaId);
        
            entity.HasOne(vp => vp.Produto)
                .WithMany()
                .HasForeignKey(vp => vp.ProdutoId);
        
            entity.Property(vp => vp.Quantidade)
                .IsRequired();
        });
        
        
    }
}