using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;

namespace Axg.Azure.WebJobs.Extensions.Dynamics.App
{
    public static class TestFunction
    {
        public static HttpClient DynamicsClient;

        [FunctionName(nameof(TestFunction))]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Post))] HttpRequest request)
        {
            var json = await request.ReadAsStringAsync();

            await DynamicsClient.PostAsync("",new ByteArrayContent(new byte[1]));
            //var (code, headers, content) = await dynamicsClient.PostAsync("WhoAmI()");
        }
    }
}
