using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace scenarios
{
    public static class BlobInput
    {
        [FunctionName("BlobInput")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")] string myQueueItem,
        [Blob("samples-workitems/{queueTrigger}", FileAccess.Read)] Stream myBlob,
        ILogger log)
        {
            try
            {
                if (myBlob.Length > 0)
                {
                    log.LogInformation($"Match found: New queue message matches a file name in blob container");
                    log.LogInformation($"BlobInput processed blob\n Name: {myQueueItem} \n Size: {myBlob.Length} bytes");
                }
            }
            catch (Exception)
            {
                log.LogInformation($"No match found: There is no file in blob container that matches the new queue message {myQueueItem}!");
            }
        }
    }
}

