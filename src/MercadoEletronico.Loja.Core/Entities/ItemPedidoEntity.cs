using System;

namespace MercadoEletronico.Loja.Core.Entities
{
    public class ItemPedidoEntity
    {
        public Guid ItemPedidoID { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public Guid PedidoID { get; set; }
        public virtual PedidoEntity Pedido { get; set; }
    }
}