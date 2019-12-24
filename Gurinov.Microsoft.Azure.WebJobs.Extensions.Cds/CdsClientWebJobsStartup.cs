using Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(CdsClientWebJobsStartup))]

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    internal sealed class CdsClientWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) => builder.AddDynamics();
    }
}
