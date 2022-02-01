using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercadoEletronico.Loja.Api.ApiModels.Requests
{
    public class PedidoRequest
    {
        [Required]
        public string Pedido { get; set; }

        [Required]
        public List<ItemPedidoRequest> Itens { get; set; }
    }
}