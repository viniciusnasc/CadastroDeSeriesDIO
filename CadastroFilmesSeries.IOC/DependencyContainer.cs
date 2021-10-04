using System;

namespace CadastroFilmesSeries.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            // Context
            services.AddDbContext<Contexto>(options => {
                options.UseSqlServer(connectionString);
            });

            // Services
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IFuncaoService, FuncaoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            // Repositorios
            services.AddScoped<IDepartamentoRepositorio, DepartamentoRepositorio>();
            services.AddScoped<IFuncaoRepositorio, FuncaoRepositorio>();
            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
}
