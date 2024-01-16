using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace Plugins;

/// <summary>
/// A plugin that returns the current time.
/// </summary>
public class TimeInformationPlugin
{
    [KernelFunction, Description("Retrieves the current time in UTC.")]
    public string GetCurrentUtcTime() => DateTime.UtcNow.ToString("R");
}