using MercadoEletronico.Loja.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Core.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<PedidoEntity> ConsultarPedidoPorIdentificacaoAsync(Guid identificador);

        Task CriarPedidoAsync(PedidoEntity Pedido);

        Task AtualizarPedidoAsync(PedidoEntity Pedido);

        Task<IEnumerable<PedidoEntity>> ConsultarTodosPedidosAsync();

        Task<PedidoEntity> ConsultarPedidoPorNumeroPedidoAsync(string numeroPedido, bool rastreavel);

        Task ExcluirPedidoPorNumeroPedidoAsync(PedidoEntity pedidoEntity);
    }
}