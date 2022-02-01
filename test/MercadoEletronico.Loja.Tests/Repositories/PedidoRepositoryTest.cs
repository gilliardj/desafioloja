using MercadoEletronico.Loja.Core.Interfaces.Repositories;
using MercadoEletronico.Loja.Infra.Contexts;
using MercadoEletronico.Loja.Infra.Repositories;
using MercadoEletronico.Loja.Tests.UnitTest.Infra;
using System.Threading.Tasks;
using Xunit;

namespace MercadoEletronico.Loja.Tests.Repositories
{
    public class PedidoRepositoryTest
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly LojaContext lojaContext;

        public PedidoRepositoryTest()
        {
            var bancoDeDadosEmMemoria = new BancoDeDadosEmMemoria();
            var context = bancoDeDadosEmMemoria.RecuperarContexto();
            _pedidoRepository = new PedidoRepository(context);
        }

        [Fact]
        public async Task NumeroPedido_RetornarPedidoEItens()
        {
            var pedido = await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync("111");
            var resultado = pedido != null;
            Assert.True(resultado);
        }
    }
}