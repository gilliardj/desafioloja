using MercadoEletronico.Loja.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Core.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<PedidoEntity> ConsultarPedidoPorIdAsync(Guid identificador);

        Task CriarPedidoAsync(PedidoEntity Pedido);

        Task AtualizarPedidoAsync(PedidoEntity Pedido);

        Task<IEnumerable<PedidoEntity>> ConsultarTodosPedidos();

        Task<PedidoEntity> ConsultarPedidoPorNumeroPedidoAsync(string numeroPedido);

        Task ExcluirPedidoPorNumeroPedidoAsync(string numeroPedido);
    }
}