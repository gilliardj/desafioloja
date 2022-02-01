using MercadoEletronico.Loja.Core.Enums;
using System.Collections.Generic;

namespace MercadoEletronico.Loja.Core.Entities
{
    public class StatusPedidoEntity
    {
        public TipoStatusEnum Status { get; set; }
        public int QuantidadeItens { get; set; }
        public decimal Valor { get; set; }
        public string NumeroPedido { get; set; }
        public List<string> ResultadoStatus { get; set; }
    }
}