using System.Threading.Tasks;
using Gurinov.Microsoft.Cds;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds.App
{
    public static class TestFunction
    {
        [FunctionName(nameof(TestFunction))]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Post))] HttpRequest request,
            [CdsClient] CdsClient client)
        {
            var json = await request.ReadAsStringAsync();
            var (code, headers, content) = await client.GetAsync("WhoAmI()");
        }
    }
}
