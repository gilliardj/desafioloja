using MercadoEletronico.Loja.Core.Entities;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Core.Interfaces.Services
{
    public interface IStatusPedidoService
    {
        Task<StatusPedidoEntity> ConsultarStatusPedidoAsync(StatusPedidoEntity statusPedidoEntity);
    }
}