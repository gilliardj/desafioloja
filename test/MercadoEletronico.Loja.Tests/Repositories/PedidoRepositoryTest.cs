using MercadoEletronico.Loja.Core.Entities;
using MercadoEletronico.Loja.Core.Interfaces.Repositories;
using MercadoEletronico.Loja.Infra.Repositories;
using MercadoEletronico.Loja.Tests.UnitTest.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MercadoEletronico.Loja.Tests.Repositories
{
    public class PedidoRepositoryTest
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoRepositoryTest()
        {
            var bancoDeDadosEmMemoria = new BancoDeDadosEmMemoria();
            var context = bancoDeDadosEmMemoria.RecuperarContexto();
            _pedidoRepository = new PedidoRepository(context);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("78965")]
        public async Task NumeroPedido_ConsultarPedidoEItens(string numeroPedido)
        {
            var pedido = await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync(numeroPedido, false);
            var resultado = pedido != null;
            Assert.True(resultado);
        }

        [Fact]
        public async Task PedidoExistente_AtualizarPedidoEItens()
        {
            var pedido = await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync("12345", false);
            string descricaoItemUm = "Batedeira Stand Mixer";
            string descricaoItemDois = "Microfone Condensador Blue";
            string descricaoItemTres = "Barbeador Philips";
            string descricaoItemQuatro = "Notebook Asus";
            string[] descricoes = { descricaoItemUm, descricaoItemDois, descricaoItemTres, descricaoItemQuatro };
            pedido.ItensPedido.Add(new Core.Entities.ItemPedidoEntity { Descricao = descricaoItemUm, PrecoUnitario = 2755m, Quantidade = 2 });
            pedido.ItensPedido.Add(new Core.Entities.ItemPedidoEntity { Descricao = descricaoItemDois, PrecoUnitario = 289m, Quantidade = 1 });
            pedido.ItensPedido.Add(new Core.Entities.ItemPedidoEntity { Descricao = descricaoItemTres, PrecoUnitario = 160m, Quantidade = 4 });
            pedido.ItensPedido.Add(new Core.Entities.ItemPedidoEntity { Descricao = descricaoItemQuatro, PrecoUnitario = 3999m, Quantidade = 1 });
            await _pedidoRepository.AtualizarPedidoAsync(pedido);
            var pedidoAtualizado = await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync(pedido.NumeroPedido, false);
            var resultado = pedidoAtualizado.ItensPedido.Count(item => descricoes.Contains(item.Descricao));
            Assert.Equal(descricoes.Count(), resultado);
        }

        [Fact]
        public async Task PedidoNovo_SalvarPedido()
        {
            PedidoEntity pedidoNovo = new PedidoEntity();
            pedidoNovo.PedidoID = Guid.NewGuid();
            pedidoNovo.NumeroPedido = "778899";
            pedidoNovo.ItensPedido = new List<ItemPedidoEntity> { new ItemPedidoEntity { Descricao = "VGA Nvidia Geforce RTX 3050", PrecoUnitario = 3500m, Quantidade = 1 }, new ItemPedidoEntity { Descricao = "CPU AMD Ryzen 5 3600", PrecoUnitario = 1200m, Quantidade = 1 } };
            await _pedidoRepository.CriarPedidoAsync(pedidoNovo);
            var pedidoRecuperado = await _pedidoRepository.ConsultarPedidoPorIdentificacaoAsync(pedidoNovo.PedidoID);
            Assert.NotNull(pedidoRecuperado);
        }

        [Fact]
        public async Task PedidoExiste_ExcluirPedido()
        {
            string numeroPedido = "12345";
            var pedidoExistente = await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync(numeroPedido, false);
            var pedidoExistenteConsultado = pedidoExistente != null;
            await _pedidoRepository.ExcluirPedidoPorNumeroPedidoAsync(pedidoExistente);
            var pedidoConsultaAposExclusao = await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync(numeroPedido, false);
            var pedidoExcluidoConsultado = pedidoConsultaAposExclusao == null;
            Assert.Equal(pedidoExistenteConsultado, pedidoExcluidoConsultado);
        }
    }
}