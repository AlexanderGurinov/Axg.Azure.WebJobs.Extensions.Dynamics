using System;
using Microsoft.Azure.WebJobs.Description;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public sealed class CdsClientAttribute : Attribute
    {
        private string _apiVersion;

        //https://github.com/Azure/azure-webjobs-sdk/wiki/Creating-custom-input-and-output-bindings
        //https://github.com/Azure/azure-functions-kafka-extension/blob/dd977eda6414490be466ca98d6f01c444470cf2e/docs/DevGuide.md#building-a-webjobs-trigger
        //https://github.com/Azure/azure-webjobs-sdk-extensions/tree/d9a17966b8987b14de024a2a9acf0b5f1ce33585/src/WebJobs.Extensions/Extensions/Timers
        [AppSetting]
        public string ApiVersion
        {
            get => _apiVersion;
            set => _apiVersion = value;
        }
        
        [AutoResolve]
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string DirectoryId { get; set; }
        public string Resource { get; set; }
    }
}
