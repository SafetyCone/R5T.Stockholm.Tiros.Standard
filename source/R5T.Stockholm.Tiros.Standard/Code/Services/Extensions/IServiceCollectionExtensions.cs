using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Stockholm.Default;
using R5T.Tiros;


namespace R5T.Stockholm.Tiros.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IStreamSerializer{T}"/> service.
        /// </summary>
        public static IServiceCollection AddTextStreamSerializer<T>(this IServiceCollection services,
            ServiceAction<ITextSerializer<T>> addTextSerializer)
        {
            services
                .AddTirosTextStreamSerializer<T>(
                    addTextSerializer,
                    ServiceAction.AddedElsewhere)
                .Configure<StreamSerializerOptions<T>>(options =>
                {
                    options.AddByteOrderMark = StreamSerializerOptions.DefaultAddByteOrderMark;
                })
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IStreamSerializer{T}"/> service.
        /// </summary>
        public static ServiceAction<IStreamSerializer<T>> AddTextStreamSerializerAction<T>(this IServiceCollection services,
            ServiceAction<ITextSerializer<T>> addTextSerializer)
        {
            var serviceAction = new ServiceAction<IStreamSerializer<T>>(() => services.AddTextStreamSerializer<T>(
                addTextSerializer));
            return serviceAction;
        }
    }
}
