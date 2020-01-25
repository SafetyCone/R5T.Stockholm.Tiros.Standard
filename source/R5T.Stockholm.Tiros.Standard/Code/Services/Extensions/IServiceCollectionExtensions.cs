﻿using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Stockholm.Default;


namespace R5T.Stockholm.Tiros.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTextStreamSerializer<T>(this IServiceCollection services)
        {
            services
                .AddSingleton<IStreamSerializer<T>, TextStreamSerializer<T>>()
                .AddSingleton<StreamSerializerOptions<T>>()
                .Configure<StreamSerializerOptions<T>>(options =>
                {
                    options.AddByteOrderMark = StreamSerializerOptions.DefaultAddByteOrderMark;
                })
                ;

            return services;
        }
    }
}
