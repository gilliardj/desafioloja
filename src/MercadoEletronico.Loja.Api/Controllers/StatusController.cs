using MercadoEletronico.Loja.Api.Adapters;
using MercadoEletronico.Loja.Api.ApiModels.Requests;
using MercadoEletronico.Loja.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusPedidoService _statusPedidoService;

        public StatusController(ILogger<StatusController> logger, IStatusPedidoService statusPedidoService)
        {
            _logger = logger;
            _statusPedidoService = statusPedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> VerificarStatusPedidoAsync([FromBody] StatusPedidoRequest statusPedidoRequest)
        {
            var statusPedidoEntity = StatusPedidoAdapter.ConverterStatusPedidoRequestParaStatusPedidoEntity(statusPedidoRequest);

            statusPedidoEntity = await _statusPedidoService.ConsultarStatusPedidoAsync(statusPedidoEntity);

            var statusPedidoResponse = StatusPedidoAdapter.ConverterStatusPedidoEntityParaStatusPedidoResponse(statusPedidoEntity);

            return Ok(statusPedidoResponse);
        }
    }
}