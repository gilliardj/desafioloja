using MercadoEletronico.Loja.Core.Interfaces.Repositories;
using MercadoEletronico.Loja.Core.Interfaces.Services;
using MercadoEletronico.Loja.Core.Services;
using MercadoEletronico.Loja.Infra.Contexts;
using MercadoEletronico.Loja.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MercadoEletronico.Loja.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var conexao = new SqliteConnection(Configuration["ConexaoSqlite:SqliteConnectionString"]);
            conexao.Open();
            services.AddDbContext<LojaContext>(options =>
                options.UseSqlite(conexao)
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MercadoEletronico.Loja.Api", Version = "v1" });
            });

            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IStatusPedidoService, StatusPedidoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MercadoEletronico.Loja.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}