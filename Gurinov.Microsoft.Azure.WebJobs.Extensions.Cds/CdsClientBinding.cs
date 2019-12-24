using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    internal sealed class CdsClientBinding : IBinding
    {
        private readonly IValueProvider _valueProvider;

        public CdsClientBinding(IValueProvider valueProvider) =>
            _valueProvider = valueProvider ?? throw new ArgumentNullException(nameof(valueProvider));

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context) => Task.FromResult(_valueProvider);

        public Task<IValueProvider> BindAsync(BindingContext context) => Task.FromResult(_valueProvider);

        public ParameterDescriptor ToParameterDescriptor() =>
            new ParameterDescriptor
            {
                Name = string.Empty,//nameof(Dynamics),
                DisplayHints = new ParameterDisplayHints
                {
                    DefaultValue = string.Empty,
                    Description = string.Empty,
                    Prompt = string.Empty
                }
            };

        public bool FromAttribute { get; } = true;
    }
}
