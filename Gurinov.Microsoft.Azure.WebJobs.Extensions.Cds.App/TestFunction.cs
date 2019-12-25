using System.Threading.Tasks;
using Gurinov.Microsoft.Cds;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds.App
{
    public static class TestFunction
    {
        [FunctionName(nameof(TestFunction))]
        //public static async Task Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)]TimerInfo timer, [CdsClient] CdsClient client, ILogger logger)
        public static void Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)]TimerInfo timer, ILogger logger)
        {
            logger.LogInformation($"Timer trigger function executed. IsPastDue={timer.IsPastDue}");

            //var (code, headers, content) = await client.GetAsync("WhoAmI()");
        }
    }
}
