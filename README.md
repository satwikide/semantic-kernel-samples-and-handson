# Overview

This solution contains examples of Semantic Kernel syntaxes and plugins. 

# Pre-requisites

This solution uses LLMs (Large language models) from Azure OpenAI. You need to have an active Azure subscription to apply for Azure OpenAI. 
1. Create an Azure OpenAI resource 
1. Create a deployment for GPT-35-Turbo model
1. Use an IDE (preferably VS Code or Visual Studio)


# Set up

1. Add the required configurations in `config\appsettings.json` file. 
1. Alternatively, you can configure user secrets in terminal as below. User secrets should be configured before running the applications. 
```
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
```

```
dotnet user-secrets init
dotnet user-secrets set "serviceType" "AzureOpenAI"
dotnet user-secrets set "serviceId" "gpt-35-turbo"
dotnet user-secrets set "deploymentId" "gpt-35-turbo-deployment-name"
dotnet user-secrets set "modelId" "gpt-3.5-turbo"
dotnet user-secrets set "endpoint" "https:// ... your endpoint ... .openai.azure.com/"
dotnet user-secrets set "apiKey" "... your Azure OpenAI key ..."
```