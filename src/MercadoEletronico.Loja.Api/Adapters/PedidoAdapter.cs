using MercadoEletronico.Loja.Api.ApiModels.Requests;
using MercadoEletronico.Loja.Api.ApiModels.Responses;
using MercadoEletronico.Loja.Core.Entities;
using System.Linq;

namespace MercadoEletronico.Loja.Api.Adapters
{
    public static class PedidoAdapter
    {
        public static PedidoEntity ConverterPedidoRequestParaPedidoEntity(PedidoRequest pedidoRequest)
        {
            PedidoEntity pedidoEntity = new PedidoEntity();
            if (pedidoRequest != null)
            {
                pedidoEntity.NumeroPedido = pedidoRequest.Pedido;
                pedidoEntity.ItensPedido = pedidoRequest?.Itens.Select(item => ItemPedidoAdapter.ConverterItemPedidoRequestParaItemPedidoEntity(item)).ToList();
            }
            return pedidoEntity;
        }

        public static PedidoResponse ConverterPedidoEntityParaPedidoResponse(PedidoEntity pedidoEntity)
        {
            PedidoResponse pedidoResponse = new PedidoResponse();
            if (pedidoEntity != null)
            {
                pedidoResponse.Pedido = pedidoEntity.NumeroPedido;
                pedidoResponse.Itens = pedidoEntity.ItensPedido?.Select(item => ItemPedidoAdapter.ConverterItemPedidoEntityParaItemPedidoResponse(item)).ToList();
            }
            return pedidoResponse;
        }

        public static PedidoEntity MesclarPeidoEntityComPedidoRequest(PedidoEntity pedidoEntity, PedidoRequest pedidoRequest)
        {
            if (pedidoEntity == null)
            {
                pedidoEntity = new PedidoEntity();
            }
            pedidoEntity.ItensPedido = pedidoRequest.Itens.Select(item => ItemPedidoAdapter.ConverterItemPedidoRequestParaItemPedidoEntity(item)).ToList();
            return pedidoEntity;
        }
    }
}