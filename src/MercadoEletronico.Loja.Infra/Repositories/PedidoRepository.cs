using MercadoEletronico.Loja.Core.Entities;
using MercadoEletronico.Loja.Core.Interfaces.Repositories;
using MercadoEletronico.Loja.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Infra.Repositories
{
    public class PedidoRepository : BaseRepository<PedidoEntity>, IPedidoRepository
    {
        private readonly LojaContext _lojaContext;

        public PedidoRepository(LojaContext lojaContext)
                : base(lojaContext)
        {
            _lojaContext = lojaContext;
        }

        public async Task<PedidoEntity> ConsultarPedidoPorIdAsync(Guid id)
        {
            return await BuscarPodIdentificadorAsync(id);
        }

        public async Task CriarPedidoAsync(PedidoEntity Pedido)
        {
            await CriarAsync(Pedido);
        }

        public async Task AtualizarPedidoAsync(PedidoEntity Pedido)
        {
            var itens = await _lojaContext.ItensPedido.Where(item => item.Pedido.PedidoID == Pedido.PedidoID).ToListAsync();
            _lojaContext.RemoveRange(itens);
            _lojaContext.Update(Pedido);
            await _lojaContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PedidoEntity>> ConsultarTodosPedidos()
        {
            return await BuscarTodos().ToListAsync();
        }

        public async Task<PedidoEntity> ConsultarPedidoPorNumeroPedidoAsync(string numeroPedido)
        {
            return await _lojaContext.Pedidos.Include(pedido => pedido.ItensPedido).AsNoTracking().FirstOrDefaultAsync(pedido => pedido.NumeroPedido == numeroPedido);
        }

        public async Task ExcluirPedidoPorNumeroPedidoAsync(string numeroPedido)
        {
            var pedidoEntity = await ConsultarPedidoPorNumeroPedidoAsync(numeroPedido);
            await ExcluirAsync(pedidoEntity);
        }
    }
}