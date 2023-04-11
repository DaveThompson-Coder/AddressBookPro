using AddressBookPro.Services.Interfaces;

namespace AddressBookPro.Services
{
    public class ImageService : IImageService
    {
        private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        private readonly string defaultImage = "img/DefaultContactImage.png";

        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null) return defaultImage;

            try
            {
                //convert the FileData to base 64, & convert to string to pass to html image tag
                //to pull image from database & display it on the form
                string imageBase64Data = Convert.ToBase64String(fileData);
                return string.Format($"data:{extension};base64,{imageBase64Data}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            try
            {
                //memoryStream class created to get incoming file from the page
                //ImageService coverts to an array of bytes then the byteFile
                //is Saved to the database
                using MemoryStream memoryStream = new();
                await file.CopyToAsync(memoryStream);
                byte[] byteFile = memoryStream.ToArray();
                return byteFile;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
