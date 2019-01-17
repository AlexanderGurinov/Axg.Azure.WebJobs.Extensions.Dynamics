using System;
using Dyrix;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    internal static class DynamicsWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddDynamics(this IWebJobsBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var dynamicsClient = new ServiceCollection()
                .AddDynamicsClient(options =>
                {
                    var configuration = builder.Services
                        .BuildServiceProvider()
                        .GetRequiredService<IConfiguration>()
                        .GetSection(nameof(DynamicsClientOptions));

                    options.ApiVersion = configuration[nameof(options.ApiVersion)];
                    options.ClientId = configuration[nameof(options.ClientId)];
                    options.ClientSecret = configuration[nameof(options.ClientSecret)];
                    options.DirectoryId = configuration[nameof(options.DirectoryId)];
                    options.Resource = configuration[nameof(options.Resource)];
                })
                .BuildServiceProvider()
                .GetRequiredService<IDynamicsClient>();

            var valueProvider = new DynamicsValueProvider((DynamicsClient)dynamicsClient);
            var binding = new DynamicsBinding(valueProvider);
            var bindingProvider = new DynamicsBindingProvider(binding);
            var extensionConfigProvider = new DynamicsExtensionConfigProvider(bindingProvider);

            builder.AddExtension(extensionConfigProvider);
            return builder;

            //     //.ConfigureOptions<DynamicsClientOptions>((configuration, path, options) =>
            //     //{
            //     //    var d = 1;
            //     //})
            //     ;

            //var c = builder.Services.BuildServiceProvider()
            //    .GetRequiredService<IConfiguration>()
            //    ;

            //var c1 = c["DynamicsClientOptions:Resource"];

            //var d = Environment.GetEnvironmentVariable("DynamicsClientOptions:Resource");


            //try
            //{
            //    var s = c.GetSection("DynamicsClientOptions");

            //    var prov = builder.Services
            //        .AddDynamicsClient(optionsBuilder => { optionsBuilder.AddConfiguration(s); })
            //        .BuildServiceProvider();




            //    DynamicsClientHolder.DynamicsClient = prov.GetService<IDynamicsClient>();


            //}
            //catch (Exception e)
            //{

            //}

        }
    }
}
