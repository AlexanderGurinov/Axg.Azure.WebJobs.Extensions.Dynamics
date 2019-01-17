using System;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    //[Extension(nameof(Dynamics))]
    internal sealed class DynamicsExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly IBindingProvider _bindingProvider;

        public DynamicsExtensionConfigProvider(IBindingProvider bindingProvider) => 
            _bindingProvider = bindingProvider ?? throw new ArgumentNullException(nameof(bindingProvider));
        
        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            context.AddBindingRule<DynamicsAttribute>().Bind(_bindingProvider);
        }
    }
}
