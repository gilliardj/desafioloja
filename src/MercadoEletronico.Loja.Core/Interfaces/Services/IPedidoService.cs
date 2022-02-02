using MercadoEletronico.Loja.Core.Entities;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Core.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<PedidoEntity> ConsultarPedidoPorNumeroPedidoAsync(string numeroPedido, bool rastreavel);

        Task CriarPedidoAsync(PedidoEntity pedidoEntity);

        Task AtualizarPedidoAsync(PedidoEntity pedidoEntity);

        Task ExcluirPedidoPorNumeroPedidoAsync(PedidoEntity pedidoEntity);
    }
}