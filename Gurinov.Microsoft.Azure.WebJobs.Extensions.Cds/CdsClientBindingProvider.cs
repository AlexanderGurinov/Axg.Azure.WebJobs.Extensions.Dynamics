using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    internal sealed class CdsClientBindingProvider : IBindingProvider
    {
        private readonly IBinding _binding;

        public CdsClientBindingProvider(IBinding binding) =>
            _binding = binding ?? throw new ArgumentNullException(nameof(binding));

        public Task<IBinding> TryCreateAsync(BindingProviderContext context) => Task.FromResult(_binding);
    }
}
