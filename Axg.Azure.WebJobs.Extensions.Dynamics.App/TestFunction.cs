using System.Threading.Tasks;
using Dyrix;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Axg.Azure.WebJobs.Extensions.Dynamics.App
{
    public static class TestFunction
    {
        [FunctionName(nameof(TestFunction))]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Post))] HttpRequest request,
            [Dynamics] DynamicsClient dynamicsClient)
        {
            var json = await request.ReadAsStringAsync();
            var (code, headers, content) = await dynamicsClient.PostAsync("WhoAmI()");
        }
    }
}
