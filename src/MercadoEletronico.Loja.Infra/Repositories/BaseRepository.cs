using MercadoEletronico.Loja.Core.Interfaces.Repositories;
using MercadoEletronico.Loja.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MercadoEletronico.Loja.Infra.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly LojaContext RepositoryContext;

        protected BaseRepository(LojaContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> BuscarTodos(bool rastreavel = false) =>
            !rastreavel
            ? RepositoryContext.Set<T>().AsNoTracking()
            : RepositoryContext.Set<T>();

        public IQueryable<T> BuscarPorCondicao(Expression<Func<T, bool>> expression, bool rastreavel)
        {
            IQueryable<T> consulta = rastreavel
                ? RepositoryContext.Set<T>().Where(expression)
                : RepositoryContext.Set<T>().Where(expression).AsNoTracking();
            return consulta;
        }

        public async Task CriarAsync(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<T> BuscarPodIdentificadorAsync(Guid identificador) => await RepositoryContext.Set<T>().FindAsync(identificador);
    }
}