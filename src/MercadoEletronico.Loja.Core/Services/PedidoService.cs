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

        public async Task AtualizarPedidoAsync(PedidoEntity pedidoEntity)
        {
            await _pedidoRepository.AtualizarPedidoAsync(pedidoEntity);
        }

        public async Task<PedidoEntity> ConsultarPedidoPorNumeroPedidoAsync(string numeroPedido, bool rastreavel)
        {
            return await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync(numeroPedido, rastreavel);
        }

        public async Task CriarPedidoAsync(PedidoEntity pedidoEntity)
        {
            await _pedidoRepository.CriarPedidoAsync(pedidoEntity);
        }

        public async Task ExcluirPedidoPorNumeroPedidoAsync(PedidoEntity pedidoEntity)
        {
            await _pedidoRepository.ExcluirPedidoPorNumeroPedidoAsync(pedidoEntity);
        }
    }
}