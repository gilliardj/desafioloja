using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MercadoEletronico.Loja.Infra.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<LojaContext>
    {
        public LojaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LojaContext>();
            optionsBuilder.UseSqlite("Data Source=loja.db;Cache=Shared");
            return new LojaContext(optionsBuilder.Options);
        }
    }
}