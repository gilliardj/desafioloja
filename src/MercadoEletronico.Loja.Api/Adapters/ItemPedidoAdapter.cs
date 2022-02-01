using MercadoEletronico.Loja.Api.ApiModels.Requests;
using MercadoEletronico.Loja.Api.ApiModels.Responses;
using MercadoEletronico.Loja.Core.Entities;

namespace MercadoEletronico.Loja.Api.Adapters
{
    public static class ItemPedidoAdapter
    {
        public static ItemPedidoEntity ConverterItemPedidoRequestParaItemPedidoEntity(ItemPedidoRequest itemPedidoRequest)
        {
            ItemPedidoEntity itemPedidoEntity = new ItemPedidoEntity();
            if (itemPedidoRequest != null)
            {
                itemPedidoEntity.Descricao = itemPedidoRequest.Descricao;
                itemPedidoEntity.PrecoUnitario = itemPedidoRequest.PrecoUnitario;
                itemPedidoEntity.Quantidade = itemPedidoRequest.Qtd;
            }
            return itemPedidoEntity;
        }

        public static ItemPedidoResponse ConverterItemPedidoEntityParaItemPedidoResponse(ItemPedidoEntity itemPedidoEntity)
        {
            ItemPedidoResponse itemPedidoResponse = new ItemPedidoResponse();
            if (itemPedidoEntity != null)
            {
                itemPedidoResponse.Descricao = itemPedidoEntity.Descricao;
                itemPedidoResponse.PrecoUnitario = itemPedidoEntity.PrecoUnitario;
                itemPedidoResponse.Qtd = itemPedidoEntity.Quantidade;
            }
            return itemPedidoResponse;
        }
    }
}