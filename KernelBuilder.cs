using Microsoft.SemanticKernel;
using Plugins;

internal static class KernelBuilder
{
    
    /// <summary>
    /// Load the settings from the default config file or from user secrets.
    /// This will add the AI (LLM) or connector to the Kernel, which will process the requests.
    /// </summary>
    static readonly KernelSettings connector = KernelSettings.LoadSettings();

    /// <summary>
    /// Initialize the kernel based on the service type.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    internal static Kernel InitializeKernel()
    {
        Console.WriteLine($"Initializing kernel with {connector.ServiceType} connector");
        if (connector.ServiceType == ServiceTypes.AzureOpenAI)
        {
            return InitializeAzureOpenAIKernel();
        }
        else if (connector.ServiceType == ServiceTypes.OpenAI)
        {
            return InitializeOpenAIKernel();
        }
        else
        {
            throw new ArgumentException($"Service type {connector.ServiceType} is not supported in this app");
        }
    }


    /// <summary>
    /// Initialize the kernel with the Azure OpenAI resource.
    /// </summary>
    /// <returns></returns>
    private static Kernel InitializeAzureOpenAIKernel()
    {
        var kernelBuilder = Kernel.CreateBuilder()
                    .AddAzureOpenAIChatCompletion(
                        endpoint: connector.Endpoint,
                        apiKey: connector.ApiKey,
                        deploymentName: connector.DeploymentOrModelId
                    );
                   
        kernelBuilder.Plugins.AddFromType<MathPlugin>();
        kernelBuilder.Plugins.AddFromType<TimeInformationPlugin>();
        kernelBuilder.Plugins.AddFromType<EmailPlugin>();

        return kernelBuilder.Build();
    }

    /// <summary>
    /// Initialize the kernel with the OpenAI.
    /// </summary>
    /// <returns></returns>
    private static Kernel InitializeOpenAIKernel()
    {
        var kernel = Kernel.CreateBuilder()
                    .AddOpenAIChatCompletion(
                        apiKey: connector.ApiKey,
                        modelId: connector.DeploymentOrModelId,
                        orgId: connector.OrgId,
                        serviceId: connector.ServiceId
                    )
                    .Build();
        return kernel;
    }
}