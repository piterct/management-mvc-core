using Gestao.App.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace Gestao.App.Configuration
{
    public static class ApplicationInsightConfig
    {

        public static IServiceCollection AddApplicationInsightConfig(this IServiceCollection services)
        {
            services.AddTransient<RequestBodyLoggingMiddleware>();

            return services;
        }
    }
}
