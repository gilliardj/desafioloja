using System.ComponentModel.DataAnnotations;

namespace MercadoEletronico.Loja.Api.ApiModels.Requests
{
    public class StatusPedidoRequest
    {
        [RegularExpression("^APROVADO$|^REPROVADO$", ErrorMessage = "Informe APROVADO ou REPROVADO")]
        public string Status { get; set; }

        public int ItensAprovados { get; set; }
        public int ValorAprovado { get; set; }

        [Required(ErrorMessage = "Informe o número do pedido")]
        public string Pedido { get; set; }
    }
}