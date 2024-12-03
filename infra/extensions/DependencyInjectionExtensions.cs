using domain.interfaces;
using domain.services;
using infra.services;
using Microsoft.Extensions.DependencyInjection;


namespace infra.extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddGoogleServices(this IServiceCollection services, string credentialsPath, string tokenPath)
        {
            services.AddSingleton<IGoogleCredentialProvider>(sp =>
                new GoogleCredentialProvider(credentialsPath, tokenPath));
            services.AddSingleton<IGoogleCalendarService, GoogleCalendarService>();
            return services;
        }
    }
}
