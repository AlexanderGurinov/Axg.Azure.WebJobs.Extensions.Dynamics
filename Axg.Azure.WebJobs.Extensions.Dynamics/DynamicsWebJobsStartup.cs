using Axg.Azure.WebJobs.Extensions.Dynamics;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(DynamicsWebJobsStartup))]

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    internal sealed class DynamicsWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) => builder.AddDynamics();
    }
}
