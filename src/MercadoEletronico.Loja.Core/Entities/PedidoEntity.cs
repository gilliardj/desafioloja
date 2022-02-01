using System;
using System.Collections.Generic;

namespace MercadoEletronico.Loja.Core.Entities
{
    public class PedidoEntity
    {
        public Guid PedidoID { get; set; }
        public string NumeroPedido { get; set; }
        public virtual ICollection<ItemPedidoEntity> ItensPedido { get; set; }
    }
}