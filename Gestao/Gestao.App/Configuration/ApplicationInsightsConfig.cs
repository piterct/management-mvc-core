using Gestao.App.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace Gestao.App.Configuration
{
    public static class ApplicationInsightsConfig
    {

        public static IServiceCollection AddApplicationInsightConfig(this IServiceCollection services)
        {
            services.AddTransient<RequestBodyLoggingMiddleware>();
            services.AddTransient<ResponseBodyLoggingMiddleware>();

            return services;
        }
    }
}
