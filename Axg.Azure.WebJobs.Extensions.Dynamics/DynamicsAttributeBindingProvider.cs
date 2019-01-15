using System.Threading.Tasks;
using Dyrix;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.DependencyInjection;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    internal sealed class DynamicsAttributeBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            // context.Parameter

            // Own service collection because of getting method not found exception with Functions v1.0.24
            var dynamicsClient = new ServiceCollection()
                .AddDynamicsClient()
                .BuildServiceProvider()
                .GetRequiredService<IDynamicsClient>() as DynamicsClient;

            var task = Task.FromResult<IValueProvider>(new DynamicsValueProvider(dynamicsClient));
            var binding = new DynamicsBinding(task);
            return Task.FromResult<IBinding>(binding);
        }
    }
}
