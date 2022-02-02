using MercadoEletronico.Loja.Api.Adapters;
using MercadoEletronico.Loja.Api.ApiModels.Requests;
using MercadoEletronico.Loja.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;

        private readonly IPedidoService _pedidoService;

        public PedidoController(ILogger<PedidoController> logger, IPedidoService pedidoService)
        {
            _logger = logger;
            _pedidoService = pedidoService;
        }

        [HttpGet("{pedido}")]
        public async Task<IActionResult> ConsultarPedidoAsync(string pedido)
        {
            if (string.IsNullOrEmpty(pedido))
            {
                return BadRequest("Favor informar o número do pedido");
            }

            var pedidoEntity = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(pedido, false);
            if (pedidoEntity == null)
            {
                return NotFound($"Número do pedido ({pedido}) não existe");
            }

            return Ok(PedidoAdapter.ConverterPedidoEntityParaPedidoResponse(pedidoEntity));
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedidoAsync([FromBody] PedidoRequest pedidoRequest)
        {
            try
            {
                var pedidoExistente = _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(pedidoRequest.Pedido, false);
                if (pedidoExistente != null)
                {
                    return BadRequest($"Número do pedido ({pedidoRequest.Pedido}) já existe");
                }

                await _pedidoService.CriarPedidoAsync(PedidoAdapter.ConverterPedidoRequestParaPedidoEntity(pedidoRequest));
                return Created(uri: $"/api/Pedido/{pedidoRequest.Pedido}", pedidoRequest);
            }
            catch (System.Exception exception)
            {
                _logger.LogError(Logging.LogBuilder.Registrar(exception));
                return BadRequest();
            }
        }

        [HttpPut("{pedido}")]
        public async Task<IActionResult> AtualizarPedidoAsync(string pedido, [FromBody] PedidoRequest pedidoRequest)
        {
            try
            {
                if (pedido != pedidoRequest.Pedido)
                    return BadRequest("Número do pedido informado incorretamente.");

                var pedidoEntity = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(pedido, true);

                if (pedidoEntity == null)
                    return NotFound($"Número do pedido ({pedido}) não existe");

                await _pedidoService.AtualizarPedidoAsync(PedidoAdapter.MesclarPeidoEntityComPedidoRequest(pedidoEntity, pedidoRequest));
                return Ok(pedidoRequest);
            }
            catch (Exception exception)
            {
                _logger.LogError(Logging.LogBuilder.Registrar(exception));
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao atualizar pedido.");
            }
        }

        [HttpDelete("{pedido}")]
        public async Task<IActionResult> ExcluirPedidoAsync(string pedido)
        {
            try
            {
                var pedidoEntity = await _pedidoService.ConsultarPedidoPorNumeroPedidoAsync(pedido, true);
                if (pedidoEntity == null)
                {
                    return NotFound($"Número do pedido ({pedido}) não existe");
                }
                await _pedidoService.ExcluirPedidoPorNumeroPedidoAsync(pedidoEntity);
                return Ok($"Número do pedido ({pedido}) removido com sucesso");
            }
            catch (Exception exception)
            {
                _logger.LogError(Logging.LogBuilder.Registrar(exception));
                return StatusCode(500, "Internal server error");
            }
        }
    }
}