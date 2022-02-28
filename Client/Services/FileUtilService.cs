using Microsoft.AspNetCore.Components.Forms;
using Client.Services;
using Client.Crypto;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace Client.Models
{
    public class FileUtilService
    {

        public static string _dragEnterStyle;
        public static IList<EncFile> fileList = new List<EncFile>();
        public static int numLines;
        private long maxFileSize = 1024 * 15;
        private int maxAllowedFiles = 3;
        public static bool isLoading = false;

        public static void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            isLoading = true;
            StateHasChanged();
            fileList = e.GetMultipleFiles()
                .Select(rawFile =>
                {
                    var buffer = new byte[rawFile.Size];
                    EncFile file = new EncFile();
                    ParametersWithIV keyParamsWithIV = AES.GenerateKeyWithIV();             
                    rawFile.OpenReadStream().ReadAsync(buffer);
                    file.Description = rawFile.Name;
                    file.RawBytes = AES.Encrypt(buffer, keyParamsWithIV);
                    return file;
                 })
                .ToList();
        }

        //https://docs.microsoft.com/en-us/aspnet/core/blazor/file-uploads?view=aspnetcore-6.0&pivots=webassembly
        public static async Task<HttpResponseMessage> Upload()        {
            try
            {
                return await HttpService.PostAsync("/api/FileInterface/Upload", fileList);
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return await new Task<HttpResponseMessage>(null);
            }
        }
      
        public static void Clear()
        {
            fileList.Clear();
        }
    }
}
