# Azure Functions C# Scenarios

This is a collection of C# function business scenarios on Azure Functions. For a comprehensive development and debugging experience, use the [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-function-python) or [VS Code extension](https://code.visualstudio.com/tutorials/functions-extension/getting-started).


### Scenarios
| Scenario | Description | Trigger | In Bindings | Out Bindings
| ------------- | ------------- | ------------- | ----------- | ----------- |
| [blob-trigger-log](functions/blob-trigger-log) | Function that writes a log when a blob is added or updated in the samples-workitems container. | Blob | NONE | NONE |
| [queue-trigger-blob-in-binding](functions/queue-trigger-blob-in-binding) | Function that uses a queue trigger and an input blob binding. The queue message contains the name of the blob, and the function logs the size of the blob. | Queue | Blob Storage | NONE |
<!-- | [blob-trigger-two-blob-out-binding](functions/blob-trigger-two-blob-out-binding) |  C# function that uses a blob trigger and two output blob bindings. The function is triggered by the creation of an image blob in the sample-images container. It creates small and medium size copies of the image blob. | Blob | NONE | Blob Storage | -->
| ... <td colspan="5"> More TBA soon... 

### Documents
* [Azure Functions C# developer guide](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library)
* [Zip push deployment for Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/deployment-zip-push)
* [Work with Azure Functions Proxies](https://docs.microsoft.com/en-us/azure/azure-functions/functions-proxies)
* [Create a function triggered by Azure Blob storage](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-blob-triggered-function)
* [Create a function triggered by Azure Cosmos DB](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-cosmos-db-triggered-function)
