using System;
using Microsoft.Azure.WebJobs.Description;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class CdsClientAttribute : Attribute
    {
        private string _apiVersion;

        //https://github.com/Azure/azure-webjobs-sdk/wiki/Creating-custom-input-and-output-bindings
        [AppSetting]
        public string ApiVersion
        {
            get => _apiVersion;
            set => _apiVersion = value;
        }
    }
}
