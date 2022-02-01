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
            return Ok(PedidoAdapter.ConverterPedidoEntityParaPedidoResponse(await _pedidoService.ConsultarPedidoPorNumeroPedido(pedido)));
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedidoAsync([FromBody] PedidoRequest pedidoRequest)
        {
            try
            {
                await _pedidoService.CriarPedido(PedidoAdapter.ConverterPedidoRequestParaPedidoEntity(pedidoRequest));
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
                    return BadRequest("Pedido informado incorretamente.");

                var pedidoEntity = await _pedidoService.ConsultarPedidoPorNumeroPedido(pedido);

                if (pedidoEntity == null)
                    return NotFound($"Pedido com número {pedido} não encontrado.");

                await _pedidoService.AtualizarPedido(PedidoAdapter.MesclarPeidoEntityComPedidoRequest(pedidoEntity, pedidoRequest));
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
                await _pedidoService.ExcluirPedidoPorNumeroPedido(pedido);
                return StatusCode(200, "Item atualizado com sucesso");
            }
            catch (Exception exception)
            {
                _logger.LogError(Logging.LogBuilder.Registrar(exception));
                return StatusCode(500, "Internal server error");
            }
        }
    }
}