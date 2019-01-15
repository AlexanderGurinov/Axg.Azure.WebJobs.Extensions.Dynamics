using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    internal sealed class DynamicsBinding : IBinding
    {
        private readonly Task<IValueProvider> _valueProviderTask;

        public DynamicsBinding(Task<IValueProvider> valueProviderTask) => 
            _valueProviderTask = valueProviderTask ?? throw new ArgumentNullException(nameof(valueProviderTask));

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            return _valueProviderTask;
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            return _valueProviderTask;
        }

        public ParameterDescriptor ToParameterDescriptor() =>
            new ParameterDescriptor
            {
                Name = nameof(Dynamics),
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
