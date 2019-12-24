using System;
using Microsoft.Azure.WebJobs.Description;

namespace Gurinov.Microsoft.Azure.WebJobs.Extensions.Cds
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public sealed class CdsClientAttribute : Attribute
    {
    }
}
