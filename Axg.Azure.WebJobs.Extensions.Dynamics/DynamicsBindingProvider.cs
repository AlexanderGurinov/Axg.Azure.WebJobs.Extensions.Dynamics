using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    internal sealed class DynamicsBindingProvider : IBindingProvider
    {
        private readonly IBinding _binding;

        public DynamicsBindingProvider(IBinding binding) =>
            _binding = binding ?? throw new ArgumentNullException(nameof(binding));

        public Task<IBinding> TryCreateAsync(BindingProviderContext context) => Task.FromResult(_binding);
    }
}
