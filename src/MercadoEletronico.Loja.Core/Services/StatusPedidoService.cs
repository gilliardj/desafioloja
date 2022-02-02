using MercadoEletronico.Loja.Core.Entities;
using MercadoEletronico.Loja.Core.Interfaces.Repositories;
using MercadoEletronico.Loja.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Core.Services
{
    public class StatusPedidoService : IStatusPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private const string QUANTIDADE_MAIOR = "QTD_A_MAIOR";
        private const string QUANTIDADE_MENOR = "QTD_A_MENOR";
        private const string VALOR_MAIOR = "VALOR_A_MAIOR";
        private const string VALOR_MENOR = "VALOR_A_MENOR";

        public StatusPedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<StatusPedidoEntity> ConsultarStatusPedidoAsync(StatusPedidoEntity statusPedidoEntity)
        {
            var pedidoConsultado = await _pedidoRepository.ConsultarPedidoPorNumeroPedidoAsync(statusPedidoEntity.NumeroPedido, false);
            statusPedidoEntity.ResultadoStatus = new List<string>();
            if (pedidoConsultado == null)
            {
                statusPedidoEntity.ResultadoStatus.Add(Enums.TipoStatusEnum.CODIGO_PEDIDO_INVALIDO.ToString());
                return statusPedidoEntity;
            }

            if (statusPedidoEntity.Status == Enums.TipoStatusEnum.REPROVADO)
            {
                statusPedidoEntity.ResultadoStatus = new List<string> { statusPedidoEntity.Status.ToString() };
                return statusPedidoEntity;
            }

            var quantidadePedido = pedidoConsultado.ItensPedido.Sum(item => item.Quantidade);
            var quantidadeStatus = statusPedidoEntity.QuantidadeItens;
            var valorPedido = pedidoConsultado.ItensPedido.Sum(item => decimal.Multiply(item.PrecoUnitario, Convert.ToDecimal(item.Quantidade)));
            var valorStatus = statusPedidoEntity.Valor;

            if (!int.Equals(quantidadePedido, quantidadeStatus))
            {
                statusPedidoEntity.ResultadoStatus.Add(CalcularAprovadoPorQuantidadePedidoComStatus(quantidadePedido, quantidadeStatus));
            }

            if (!int.Equals(valorPedido, valorStatus))
            {
                statusPedidoEntity.ResultadoStatus.Add(CalcularAprovadoPorValorPedidoComStatus(valorPedido, valorStatus));
            }

            if (statusPedidoEntity.ResultadoStatus.Count == default(int))
            {
                statusPedidoEntity.ResultadoStatus.Add(statusPedidoEntity.Status.ToString());
            }

            return statusPedidoEntity;
        }

        private string CalcularAprovadoPorQuantidadePedidoComStatus(int quantidadePedido, int quantidadeStatus)
        {
            return quantidadePedido > quantidadeStatus ? $"APROVADO_{QUANTIDADE_MENOR}" : $"APROVADO_{QUANTIDADE_MAIOR}";
        }

        private string CalcularAprovadoPorValorPedidoComStatus(decimal valorPedido, decimal valorStatus)
        {
            return valorPedido > valorStatus ? $"APROVADO_{VALOR_MENOR}" : $"APROVADO_{VALOR_MAIOR}";
        }
    }
}