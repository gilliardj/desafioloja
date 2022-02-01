using MercadoEletronico.Loja.Core.Entities;
using MercadoEletronico.Loja.Core.Interfaces.Repositories;
using MercadoEletronico.Loja.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Tests.Service
{
    public class PedidoServiceTest : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public Task AtualizarPedido(PedidoEntity pedidoEntity)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoEntity> ConsultarPedidoPorNumeroPedido(string numeroPedido)
        {
            throw new NotImplementedException();
        }

        public Task CriarPedido(PedidoEntity pedidoEntity)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirPedidoPorNumeroPedido(string numeroPedido)
        {
            throw new NotImplementedException();
        }
    }
}