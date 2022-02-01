using MercadoEletronico.Loja.Core.Entities;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Core.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<PedidoEntity> ConsultarPedidoPorNumeroPedido(string numeroPedido);

        Task CriarPedido(PedidoEntity pedidoEntity);

        Task AtualizarPedido(PedidoEntity pedidoEntity);

        Task ExcluirPedidoPorNumeroPedido(string numeroPedido);
    }
}