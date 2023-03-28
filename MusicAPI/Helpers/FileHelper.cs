using Azure.Storage.Blobs;
using MusicAPI.Models;

namespace MusicAPI.Helpers
{
    public class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile file) {
            var connectionString = @"DefaultEndpointsProtocol=https;AccountName=musicstorageproject;AccountKey=EhSU3yQuCZNHLyjbYtJQcAa4yoMLixO794OnFqyGWdZY1gl3R+IyuOEvA4DAaZf+O3QMAA1nthIo+AStohDlUA==;EndpointSuffix=core.windows.net";
            var containerName = "songscover";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }

        public static async Task<string> UploadAudioFile(IFormFile file)
        {
            var connectionString = @"DefaultEndpointsProtocol=https;AccountName=musicstorageproject;AccountKey=EhSU3yQuCZNHLyjbYtJQcAa4yoMLixO794OnFqyGWdZY1gl3R+IyuOEvA4DAaZf+O3QMAA1nthIo+AStohDlUA==;EndpointSuffix=core.windows.net";
            var containerName = "audiofiles";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
