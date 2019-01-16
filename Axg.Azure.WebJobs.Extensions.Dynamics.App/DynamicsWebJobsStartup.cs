using System;
using System.Net.Http.Headers;
using Axg.Azure.WebJobs.Extensions.Dynamics.App;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(DynamicsWebJobsStartup))]

namespace Axg.Azure.WebJobs.Extensions.Dynamics.App
{
    public class DynamicsWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var provider = builder.Services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            var options = new DynamicsClientOptions();
            configuration.Bind(options);

            var dynamicsClient = TestFunction.DynamicsClient;
            dynamicsClient.BaseAddress = new Uri($"{options.Resource}/api/data/v{options.ApiVersion}/");
            dynamicsClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            dynamicsClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            dynamicsClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }
    }
}
