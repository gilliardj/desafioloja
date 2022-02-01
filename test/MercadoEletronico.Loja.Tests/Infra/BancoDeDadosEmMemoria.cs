using MercadoEletronico.Loja.Core.Entities;
using MercadoEletronico.Loja.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MercadoEletronico.Loja.Tests.UnitTest.Infra
{
    public class BancoDeDadosEmMemoria
    {
        private Loja.Infra.Contexts.LojaContext _lojaContext;

        public LojaContext RecuperarContexto() => _lojaContext;

        public BancoDeDadosEmMemoria()
        {
            var conexao = new SQLiteConnection("Data Source=:memory:");
            conexao.Open();

            var options = new DbContextOptionsBuilder<LojaContext>().UseSqlite(conexao).EnableSensitiveDataLogging().Options;
            _lojaContext = new LojaContext(options);
            InserirDadosFalsos();
        }

        private void InserirDadosFalsos()
        {
            if (_lojaContext.Database.EnsureCreated())
            {
                PedidoEntity pedido = new PedidoEntity();
                pedido.PedidoID = new Guid();
                pedido.NumeroPedido = "123";
                pedido.ItensPedido = new List<ItemPedidoEntity> { new ItemPedidoEntity { Descricao = "VGA Nvidia Geforce RTX 3050", PrecoUnitario = 3500m, Quantidade = 1 }, new ItemPedidoEntity { Descricao = "CPU AMD Ryzen 5 3600", PrecoUnitario = 1200m, Quantidade = 1 } };
                _lojaContext.Pedidos.Add(pedido);

                _lojaContext.SaveChanges();
            }
        }
    }
}