namespace MercadoEletronico.Loja.Api.ApiModels.Responses
{
    public class ItemPedidoResponse
    {
        public string Descricao { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int Qtd { get; set; }
    }
}