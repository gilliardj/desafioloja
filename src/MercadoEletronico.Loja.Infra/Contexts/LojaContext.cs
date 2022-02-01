using MercadoEletronico.Loja.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MercadoEletronico.Loja.Infra.Contexts
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        {
        }

        public DbSet<PedidoEntity> Pedidos { get; set; }
        public DbSet<ItemPedidoEntity> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Pedido => pedidos

            modelBuilder.Entity<PedidoEntity>(
                        t => t
                        .ToTable("pedidos")
                        .HasKey(k => k.PedidoID)
                        );

            modelBuilder.Entity<PedidoEntity>()
                        .Property(p => p.PedidoID)
                        .HasColumnName("id")
                        .IsRequired();

            modelBuilder.Entity<PedidoEntity>()
                        .Property(p => p.NumeroPedido)
                        .HasColumnName("numero_pedido")
                        .IsRequired();

            //modelBuilder.Entity<PedidoEntity>()
            //            .Property(p => p.Ativo)
            //            .HasColumnName("ativo")
            //            .IsRequired();

            #endregion Pedido => pedidos

            #region ItemPedido => itens_pedido

            modelBuilder.Entity<ItemPedidoEntity>(
                        t => t
                        .ToTable("itens_pedido")
                        .HasKey(k => k.ItemPedidoID)
                        );

            modelBuilder.Entity<ItemPedidoEntity>()
                        .Property(p => p.ItemPedidoID)
                        .HasColumnName("id")
                        .IsRequired();

            modelBuilder.Entity<ItemPedidoEntity>()
                        .Property(p => p.Descricao)
                        .HasColumnName("descricao")
                        .IsRequired();

            modelBuilder.Entity<ItemPedidoEntity>()
                        .Property(p => p.Quantidade)
                        .HasColumnName("quantidade")
                        .IsRequired();

            modelBuilder.Entity<ItemPedidoEntity>()
                        .Property(p => p.PrecoUnitario)
                        .HasColumnName("preco_unitario")
                        .IsRequired();

            modelBuilder.Entity<ItemPedidoEntity>()
                        .HasOne(e => e.Pedido)
                        .WithMany(e => e.ItensPedido)
                        .HasForeignKey(f => f.PedidoID)
                        .OnDelete(DeleteBehavior.NoAction);

            #endregion ItemPedido => itens_pedido

            base.OnModelCreating(modelBuilder);
        }
    }
}