using System.Collections.Generic;

namespace MercadoEletronico.Loja.Api.ApiModels.Responses
{
    public class PedidoResponse
    {
        public string Pedido { get; set; }
        public ICollection<ItemPedidoResponse> Itens { get; set; }
    }
}