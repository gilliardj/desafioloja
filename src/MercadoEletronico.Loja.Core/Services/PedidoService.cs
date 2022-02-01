using MercadoEletronico.Loja.Core.Entities;
using MercadoEletronico.Loja.Core.Interfaces.Repositories;
using MercadoEletronico.Loja.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Core.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task AtualizarPedido(PedidoEntity pedidoEntity)
        {
            await _pedidoRepository.AtualizarPedidoAsync(pedidoEntity);
        }

        public async Task<PedidoEntity> ConsultarPedidoPorNumeroPedido(string numeroPedido)
        {
            return await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync(numeroPedido);
        }

        public async Task CriarPedido(PedidoEntity pedidoEntity)
        {
            await _pedidoRepository.CriarPedidoAsync(pedidoEntity);
        }

        public async Task ExcluirPedidoPorNumeroPedido(string numeroPedido)
        {
            await _pedidoRepository.ExcluirPedidoPorNumeroPedidoAsync(numeroPedido);
        }
    }
}