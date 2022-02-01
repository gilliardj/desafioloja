using System.Collections.Generic;

namespace MercadoEletronico.Loja.Api.ApiModels.Responses
{
    public class StatusPedidoResponse
    {
        public string Pedido { get; set; }
        public ICollection<string> Status { get; set; }
    }
}