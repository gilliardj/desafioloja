using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> BuscarPodIdentificadorAsync(Guid identificador);

        IQueryable<T> BuscarTodos(bool rastreavel);

        IQueryable<T> BuscarPorCondicao(Expression<Func<T, bool>> expression, bool rastreavel);

        Task CriarAsync(T entidade);

        Task AtualizarAsync(T entidade);

        Task ExcluirAsync(T entidade);
    }
}