using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
namespace scenarios
{
    public static class UnZipFile
    {
        [FunctionName("UnZipFile")]
        public static async Task Run([BlobTrigger("input-files/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            try
            {
                // Step 01: Get destination Storage account connection string from local.setting.json and container name 
                string destinationStorage = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
                string destinationContainer = "output-files";

                // Step 02: Check if it's a zip file
                if (name.Split('.').Last().ToLower() == "zip")
                {
                    // Step 03: Create an archive from the stream
                    ZipArchive archive = new ZipArchive(myBlob);

                    // Step 04: Create a reference to storage account, blob, container
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(destinationStorage);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(destinationContainer);
                    await container.CreateIfNotExistsAsync();

                    // Step 05: Loop through each file in the archive, create blob and upload
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        log.LogInformation($"Now processing {entry.FullName}");

                        CloudBlockBlob blockBlob = container.GetBlockBlobReference(entry.Name);
                        using (var fileStream = entry.Open())
                        {
                            await blockBlob.UploadFromStreamAsync(fileStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogInformation($"Error! Something went wrong: {ex.Message}");
            }
        }
    }
}
