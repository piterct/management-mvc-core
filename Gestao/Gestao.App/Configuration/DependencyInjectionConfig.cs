using Gestao.App.Caching;
using Gestao.App.Extensions;
using Gestao.Business.Interfaces;
using Gestao.Business.Notificacoes;
using Gestao.Business.Queries.Fornecedor;
using Gestao.Business.Services;
using Gestao.Data.Context;
using Gestao.Data.Repository;
using Gestao.Data.Repository.Queries;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Gestao.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<GestaoDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorQuery,FornecedorQuery>();

            return services;
        }

        public static IServiceCollection EnableCache(this IServiceCollection services)
        {
            services.AddScoped<FornecedorRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorCaching<FornecedorRepository>>();

            return services;
        }
    }
}
