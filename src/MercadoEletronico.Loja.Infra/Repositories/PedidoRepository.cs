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

        public async Task<PedidoEntity> ConsultarPedidoPorIdentificacaoAsync(Guid id)
        {
            return await BuscarPodIdentificadorAsync(id);
        }

        public async Task CriarPedidoAsync(PedidoEntity pedidoEntity)
        {
            await CriarAsync(pedidoEntity);
        }

        public async Task AtualizarPedidoAsync(PedidoEntity pedidoEntity)
        {
            var itens = await _lojaContext.ItensPedido.Where(item => item.Pedido.PedidoID == pedidoEntity.PedidoID).ToListAsync();
            _lojaContext.RemoveRange(itens);
            _lojaContext.Update(pedidoEntity);
            await _lojaContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PedidoEntity>> ConsultarTodosPedidosAsync()
        {
            return await BuscarTodos().ToListAsync();
        }

        public async Task<PedidoEntity> ConsultarPedidoPorNumeroPedidoAsync(string numeroPedido, bool rastreavel)
        {
            return
                rastreavel
                ?
                await _lojaContext.Pedidos.Include(pedido => pedido.ItensPedido).AsNoTracking().FirstOrDefaultAsync(pedido => pedido.NumeroPedido == numeroPedido)
                :
                await _lojaContext.Pedidos.Include(pedido => pedido.ItensPedido).FirstOrDefaultAsync(pedido => pedido.NumeroPedido == numeroPedido)
                ;
        }

        public async Task ExcluirPedidoPorNumeroPedidoAsync(PedidoEntity pedidoEntity)
        {
            await ExcluirAsync(pedidoEntity);
        }
    }
}