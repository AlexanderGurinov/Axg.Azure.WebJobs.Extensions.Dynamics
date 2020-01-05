using System;
using Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds;
using Gurinov.Microsoft.Cds;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(CdsClientWebJobsStartup))]

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    internal sealed class CdsClientWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services
                .AddCdsClient()
                .AddSingleton<Func<CdsClientAttribute, ICdsClient>>(provider => attribute => provider.GetRequiredService<ICdsClient>());

            builder.AddExtension<CdsClientExtensionConfigProvider>()
                .BindOptions<CdsClientOptions>();
        }
    }
}
