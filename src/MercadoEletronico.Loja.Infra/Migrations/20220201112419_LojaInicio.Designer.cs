// <auto-generated />
using System;
using MercadoEletronico.Loja.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MercadoEletronico.Loja.Infra.Migrations
{
    [DbContext(typeof(LojaContext))]
    [Migration("20220201112419_LojaInicio")]
    partial class LojaInicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("MercadoEletronico.Loja.Core.Entities.ItemPedidoEntity", b =>
                {
                    b.Property<Guid>("ItemPedidoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("descricao");

                    b.Property<Guid>("PedidoID")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("TEXT")
                        .HasColumnName("preco_unitario");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER")
                        .HasColumnName("quantidade");

                    b.HasKey("ItemPedidoID");

                    b.HasIndex("PedidoID");

                    b.ToTable("itens_pedido");
                });

            modelBuilder.Entity("MercadoEletronico.Loja.Core.Entities.PedidoEntity", b =>
                {
                    b.Property<Guid>("PedidoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("NumeroPedido")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("numero_pedido");

                    b.HasKey("PedidoID");

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("MercadoEletronico.Loja.Core.Entities.ItemPedidoEntity", b =>
                {
                    b.HasOne("MercadoEletronico.Loja.Core.Entities.PedidoEntity", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("MercadoEletronico.Loja.Core.Entities.PedidoEntity", b =>
                {
                    b.Navigation("ItensPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
