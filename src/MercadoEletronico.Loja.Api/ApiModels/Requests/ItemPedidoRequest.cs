using System.ComponentModel.DataAnnotations;

namespace MercadoEletronico.Loja.Api.ApiModels.Requests
{
    public class ItemPedidoRequest
    {
        private const string VALOR_UM_CENTAVO_TIPO_DECIMAL = "0.1";
        private const string MAXIMO_VALOR_TIPO_DECIMAL = "999999.99";
        private const int VALOR_UM_TIPO_INTEIRO = 1;
        private const int VALOR_MAXIMO_TIPO_INTEIRO = 999;

        [Required]
        public string Descricao { get; set; }

        [Required]
        [Range(typeof(decimal), VALOR_UM_CENTAVO_TIPO_DECIMAL, MAXIMO_VALOR_TIPO_DECIMAL, ErrorMessage = "Preço Unitário deve ser maior que 0 (Zero) e menor que 999999.99 (noventa e nove milhões e novecentos e noventa e nove mil e novecentos e noventa e nove)")]
        public decimal PrecoUnitario { get; set; }

        [Required]
        [Range(VALOR_UM_TIPO_INTEIRO, VALOR_MAXIMO_TIPO_INTEIRO, ErrorMessage = "Quantidade deve ser maior que 0 (Zero) e menor que 999 (novecentos e noventa e nove)")]
        public int Qtd { get; set; }
    }
}