using MercadoEletronico.Loja.Core.Entities;
using MercadoEletronico.Loja.Core.Interfaces.Services;
using MercadoEletronico.Loja.Core.Services;
using MercadoEletronico.Loja.Infra.Repositories;
using MercadoEletronico.Loja.Tests.UnitTest.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MercadoEletronico.Loja.Tests.Service
{
    public class PedidoServiceTest
    {
        private readonly IPedidoService _pedidoService;

        public PedidoServiceTest()
        {
            BancoDeDadosEmMemoria bancoDeDadosEmMemoria = new BancoDeDadosEmMemoria();
            var pedidoRepository = new PedidoRepository(bancoDeDadosEmMemoria.RecuperarContexto());
            _pedidoService = new PedidoService(pedidoRepository);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("78965")]
        public async Task NumeroPedido_ConsultarPedidoEItens(string numeroPedido)
        {
            var pedido = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(numeroPedido, false);
            Assert.NotNull(pedido);
        }

        [Fact]
        public async Task PedidoExistente_AtualizarPedido()
        {
            var pedido = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync("78965", false);
            string descricaoItemUm = "Batedeira Stand Mixer";
            string descricaoItemDois = "Microfone Condensador Blue";
            string descricaoItemTres = "Barbeador Philips";
            string descricaoItemQuatro = "Notebook Asus";
            string[] descricoes = { descricaoItemUm, descricaoItemDois, descricaoItemTres, descricaoItemQuatro };
            pedido.ItensPedido.Add(new Core.Entities.ItemPedidoEntity { Descricao = descricaoItemUm, PrecoUnitario = 2755m, Quantidade = 2 });
            pedido.ItensPedido.Add(new Core.Entities.ItemPedidoEntity { Descricao = descricaoItemDois, PrecoUnitario = 289m, Quantidade = 1 });
            pedido.ItensPedido.Add(new Core.Entities.ItemPedidoEntity { Descricao = descricaoItemTres, PrecoUnitario = 160m, Quantidade = 4 });
            pedido.ItensPedido.Add(new Core.Entities.ItemPedidoEntity { Descricao = descricaoItemQuatro, PrecoUnitario = 3999m, Quantidade = 1 });
            await _pedidoService.AtualizarPedidoAsync(pedido);
            var pedidoAtualizado = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(pedido.NumeroPedido, false);
            var resultado = pedidoAtualizado.ItensPedido.Count(item => descricoes.Contains(item.Descricao));
            Assert.Equal(descricoes.Count(), resultado);
        }

        [Fact]
        public async Task PedidoNovo_SalvarPedido()
        {
            PedidoEntity pedidoNovo = new PedidoEntity();
            pedidoNovo.PedidoID = Guid.NewGuid();
            pedidoNovo.NumeroPedido = "886454";
            pedidoNovo.ItensPedido = new List<ItemPedidoEntity> { new ItemPedidoEntity { Descricao = "VGA Nvidia Geforce RTX 3050", PrecoUnitario = 3500m, Quantidade = 1 }, new ItemPedidoEntity { Descricao = "CPU AMD Ryzen 5 3600", PrecoUnitario = 1200m, Quantidade = 1 } };
            await _pedidoService.CriarPedidoAsync(pedidoNovo);
            var pedidoRecuperado = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(pedidoNovo.NumeroPedido, false);
            Assert.NotNull(pedidoRecuperado);
        }

        [Fact]
        public async Task PedidoExiste_ExcluirPedido()
        {
            string numeroPedido = "65784";
            var pedidoExistente = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(numeroPedido, false);
            var pedidoExistenteConsultado = pedidoExistente != null;
            await _pedidoService.ExcluirPedidoPorNumeroPedidoAsync(pedidoExistente);
            var pedidoConsultaAposExclusao = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(numeroPedido, false);
            var pedidoExcluidoConsultado = pedidoConsultaAposExclusao == null;
            Assert.Equal(pedidoExistenteConsultado, pedidoExcluidoConsultado);
        }
    }
}