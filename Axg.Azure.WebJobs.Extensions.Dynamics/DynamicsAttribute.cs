using Microsoft.Azure.WebJobs.Description;
using System;

namespace Axg.Azure.WebJobs.Extensions.Dynamics
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public sealed class DynamicsAttribute : Attribute
    {
    }
}
