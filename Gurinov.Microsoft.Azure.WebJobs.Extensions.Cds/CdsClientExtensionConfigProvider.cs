using System;
using Gurinov.Microsoft.Cds;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    internal sealed class CdsClientExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly Func<CdsClientAttribute, ICdsClient> _builder;

        public CdsClientExtensionConfigProvider(Func<CdsClientAttribute, ICdsClient> builder) => 
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            context.AddBindingRule<CdsClientAttribute>()
                .BindToInput(_builder);
        }
    }
}
