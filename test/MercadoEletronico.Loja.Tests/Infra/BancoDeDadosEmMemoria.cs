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
                PedidoEntity pedidoUm = new PedidoEntity();
                pedidoUm.PedidoID = Guid.NewGuid();
                pedidoUm.NumeroPedido = "12345";
                pedidoUm.ItensPedido = new List<ItemPedidoEntity> { new ItemPedidoEntity { Descricao = "VGA Nvidia Geforce RTX 3050", PrecoUnitario = 3500m, Quantidade = 1 }, new ItemPedidoEntity { Descricao = "CPU AMD Ryzen 5 3600", PrecoUnitario = 1200m, Quantidade = 1 } };
                _lojaContext.Pedidos.Add(pedidoUm);

                PedidoEntity pedidoDois = new PedidoEntity();
                pedidoDois.PedidoID = Guid.NewGuid();
                pedidoDois.NumeroPedido = "78965";
                pedidoDois.ItensPedido = new List<ItemPedidoEntity> { new ItemPedidoEntity { Descricao = "Geladeira Brastemp Duas portas", PrecoUnitario = 6400m, Quantidade = 1 }, new ItemPedidoEntity { Descricao = "Liquidificador Arno", PrecoUnitario = 390m, Quantidade = 3 } };
                _lojaContext.Pedidos.Add(pedidoDois);

                PedidoEntity pedidoTres = new PedidoEntity();
                pedidoTres.PedidoID = Guid.NewGuid();
                pedidoTres.NumeroPedido = "65784";
                pedidoTres.ItensPedido = new List<ItemPedidoEntity> { new ItemPedidoEntity { Descricao = "Fogão Brastemp", PrecoUnitario = 950m, Quantidade = 2 }, new ItemPedidoEntity { Descricao = "Batedeira Arno", PrecoUnitario = 180m, Quantidade = 4 }, new ItemPedidoEntity { Descricao = "Monitor AOC", PrecoUnitario = 770m, Quantidade = 2 } };
                _lojaContext.Pedidos.Add(pedidoTres);

                _lojaContext.SaveChanges();
            }
        }
    }
}