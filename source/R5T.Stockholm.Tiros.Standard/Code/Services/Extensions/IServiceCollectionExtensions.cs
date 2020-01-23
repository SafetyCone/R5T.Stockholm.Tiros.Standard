using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.Stockholm.Tiros.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTextStreamSerializer<T>(this IServiceCollection services)
        {
            services.AddSingleton<IStreamSerializer<T>, TextStreamSerializer<T>>();

            return services;
        }
    }
}
