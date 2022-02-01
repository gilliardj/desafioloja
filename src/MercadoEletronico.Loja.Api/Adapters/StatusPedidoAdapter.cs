using MercadoEletronico.Loja.Api.ApiModels.Requests;
using MercadoEletronico.Loja.Api.ApiModels.Responses;
using MercadoEletronico.Loja.Core.Entities;
using MercadoEletronico.Loja.Core.Enums;

namespace MercadoEletronico.Loja.Api.Adapters
{
    public static class StatusPedidoAdapter
    {
        public static StatusPedidoEntity ConverterStatusPedidoRequestParaStatusPedidoEntity(StatusPedidoRequest statusPedidoRequest)
        {
            StatusPedidoEntity statusPedidoEntity = new StatusPedidoEntity();
            if (statusPedidoRequest != null)
            {
                statusPedidoEntity.Status = (TipoStatusEnum)System.Enum.Parse(typeof(TipoStatusEnum), statusPedidoRequest.Status);
                statusPedidoEntity.QuantidadeItens = statusPedidoRequest.ItensAprovados;
                statusPedidoEntity.Valor = statusPedidoRequest.ValorAprovado;
                statusPedidoEntity.NumeroPedido = statusPedidoRequest.Pedido;
            }
            return statusPedidoEntity;
        }

        public static StatusPedidoResponse ConverterStatusPedidoEntityParaStatusPedidoResponse(StatusPedidoEntity statusPedidoEntity)
        {
            StatusPedidoResponse statusPedidoResponse = new StatusPedidoResponse();
            if (statusPedidoEntity != null)
            {
                statusPedidoResponse.Pedido = statusPedidoEntity.NumeroPedido;
                statusPedidoResponse.Status = statusPedidoEntity.ResultadoStatus;
            }
            return statusPedidoResponse;
        }
    }
}