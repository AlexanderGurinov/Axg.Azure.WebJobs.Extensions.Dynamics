using System;
using Gurinov.Microsoft.Cds;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    [Extension(nameof(CdsClient))]
    internal sealed class CdsClientExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly IBindingProvider _bindingProvider;

        public CdsClientExtensionConfigProvider(IBindingProvider bindingProvider) => 
            _bindingProvider = bindingProvider ?? throw new ArgumentNullException(nameof(bindingProvider));
        
        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            context.AddBindingRule<CdsClientAttribute>().Bind(_bindingProvider);
        }
    }
}
