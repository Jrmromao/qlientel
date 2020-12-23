using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Azure.BlobOps
{
    public class UploadBlob
    {
        public UploadBlob()
        {
            //BlobClient = new BlobServiceClient(Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING"));
        }

        public static string ConnectionString { get; set; }
        public static BlobServiceClient BlobClient { get; set; }

        public static async Task<Uri> UploadBlopToContainner(string containerName,string path, string directory, IFormFile doc)
        {
            try
            {
                BlobClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=manageirostorage;AccountKey=ClfhRzRXbNLtEe0EPDz/xwZIF5Sg2bjr9pbLsHz6oWNakTECBN4NKOTA42CfXQLxCsG2tPlHLtGHe2LLZLIeOA==;EndpointSuffix=core.windows.net");

                BlobContainerClient containerClient = BlobClient.GetBlobContainerClient(containerName.ToLower());
                BlobClient blobClient = containerClient.GetBlobClient($"{path}/{directory}/{doc.FileName}");
                var stream = doc.OpenReadStream();
                var success = await blobClient.UploadAsync(stream, true);

                stream.Close();

                return blobClient.Uri;
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine("HTTP error code {0}: {1}", e.Status, e.ErrorCode);
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}