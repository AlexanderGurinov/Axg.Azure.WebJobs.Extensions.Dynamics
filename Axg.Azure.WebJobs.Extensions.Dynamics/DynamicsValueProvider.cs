using System;
using System.Threading.Tasks;
using Dyrix;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    internal sealed class DynamicsValueProvider : IValueProvider
    {
        private readonly DynamicsClient _dynamicsClient;

        public DynamicsValueProvider(DynamicsClient dynamicsClient) =>
            _dynamicsClient = dynamicsClient ?? throw new ArgumentNullException(nameof(dynamicsClient));

        public Task<object> GetValueAsync() => Task.FromResult<object>(_dynamicsClient);

        public string ToInvokeString() => _dynamicsClient.ToString();

        public Type Type { get; } = typeof(DynamicsClient);
    }
}