using Azure.Storage.Blobs;
using System;
using System.Threading.Tasks;

namespace Azure
{
    public class Create
    {
        public static string ConnectionString { get; set; }
        public static BlobServiceClient BlobClient { get; set; }

        public static async Task<bool> CreateCompanyContainerAsync(string containerName)
        {
            BlobClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=manageirostorage;AccountKey=ClfhRzRXbNLtEe0EPDz/xwZIF5Sg2bjr9pbLsHz6oWNakTECBN4NKOTA42CfXQLxCsG2tPlHLtGHe2LLZLIeOA==;EndpointSuffix=core.windows.net");

            var container = BlobClient.GetBlobContainerClient(containerName);

            try
            {
                if (!container.Exists())
                    await BlobClient.CreateBlobContainerAsync(containerName);

                return await container.ExistsAsync();
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine("HTTP error code {0}: {1}", e.Status, e.ErrorCode);
                Console.WriteLine(e.Message);
            }

            return await container.ExistsAsync();
        }
    }
}