using System;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    [Extension(nameof(Dynamics))]
    internal sealed class DynamicsExtensionConfigProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var bindingProvider = new DynamicsAttributeBindingProvider();
            context.AddBindingRule<DynamicsAttribute>().Bind(bindingProvider);
        }
    }
}
