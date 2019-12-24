using System;
using Gurinov.Microsoft.Cds;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    internal static class CdsClientWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddDynamics(this IWebJobsBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var client = new ServiceCollection()
                .AddCdsClient(options =>
                {
                    var configuration = builder.Services
                        .BuildServiceProvider()
                        .GetRequiredService<IConfiguration>()
                        .GetSection(nameof(CdsClientOptions));

                    options.ApiVersion = configuration[nameof(options.ApiVersion)];
                    options.ClientId = configuration[nameof(options.ClientId)];
                    options.ClientSecret = configuration[nameof(options.ClientSecret)];
                    options.DirectoryId = configuration[nameof(options.DirectoryId)];
                    options.Resource = configuration[nameof(options.Resource)];
                })
                .BuildServiceProvider()
                .GetRequiredService<ICdsClient>();

            var valueProvider = new CdsClientValueProvider((CdsClient)client);
            var binding = new CdsClientBinding(valueProvider);
            var bindingProvider = new CdsClientBindingProvider(binding);
            var extensionConfigProvider = new CdsClientExtensionConfigProvider(bindingProvider);

            builder.AddExtension(extensionConfigProvider);
            return builder;
        }
    }
}
