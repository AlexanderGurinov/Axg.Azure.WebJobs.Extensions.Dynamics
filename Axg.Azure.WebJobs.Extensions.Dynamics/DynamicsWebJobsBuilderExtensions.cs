using System;
using System.Diagnostics;
using Dyrix;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    internal static class DynamicsWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddDynamics(this IWebJobsBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

           builder.AddExtension<DynamicsExtensionConfigProvider>()
                //.ConfigureOptions<DynamicsClientOptions>((configuration, path, options) =>
                //{
                //    var d = 1;
                //})
                ;


           // builder.Services.TryAddSingleton<DynamicsClient>();

            return builder;
        }
    }
}
