using System;
using System.Threading.Tasks;
using Gurinov.Microsoft.Cds;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    internal sealed class CdsClientValueProvider : IValueProvider
    {
        private readonly CdsClient _client;

        public CdsClientValueProvider(CdsClient client) =>
            _client = client ?? throw new ArgumentNullException(nameof(client));

        public Task<object> GetValueAsync() => Task.FromResult<object>(_client);

        public string ToInvokeString() => _client.ToString();

        public Type Type { get; } = typeof(CdsClient);
    }
}