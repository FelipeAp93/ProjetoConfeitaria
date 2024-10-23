using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {


    }

    public DbSet<Categoria> Categorias  { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }


   
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //Fluent API


        // Categoria
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(c => c.CategoriaId);
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(70);
            entity.HasMany(c => c.Produtos).WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);
        });

        // Cliente
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(70);
            entity.Property(c => c.Email).IsRequired().HasMaxLength(50);
            entity.Property(c => c.Telefone).HasMaxLength(15);
            entity.HasMany(c => c.Pedidos).WithOne(p => p.Cliente).HasForeignKey(p => p.ClienteId);
        });

        // Pedido
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.DataPedido).IsRequired();
            entity.HasMany(p => p.ItensPedido).WithOne(i => i.Pedido).HasForeignKey(i => i.PedidoId);
            entity.Property(p => p.Status).IsRequired().HasMaxLength(20);
        });


        // ItemPedido
        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Quantidade).IsRequired();
            entity.Property(i => i.PrecoUnitario).HasColumnType("decimal(18,2)").IsRequired();
            entity.HasOne(i => i.Produto)            // ItemPedido -> Produto
                .WithMany()                          // Produto pode ter muitos ItemPedidos
                .HasForeignKey(i => i.ProdutoId);    // Chave estrangeira em ItemPedido

            entity.HasOne(i => i.Pedido)             // ItemPedido -> Pedido
                .WithMany(p => p.ItensPedido)        // Um Pedido pode ter muitos ItemPedidos
                .HasForeignKey(i => i.PedidoId);     // Chave estrangeira em ItemPedido
        });


        // Produto
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Descricao).HasMaxLength(250);
            entity.Property(p => p.Preco).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(p => p.Disponivel).IsRequired();
            entity.HasOne(p => p.Categoria).WithMany(c => c.Produtos).HasForeignKey(p => p.CategoriaId);
        });
    }

}
