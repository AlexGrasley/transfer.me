using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Client.Services;
using Client.Crypto;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Client.Pages;
using System.Net;

namespace Client.Models
{
    public class FileUtilService
    {
        private static string? dragEnterStyle;
        public static int numLines;
        public static long maxFileSize = 1024 * 15;

        public static string DragEnterStyle { get => dragEnterStyle?? "drag-enter"; set => dragEnterStyle = value; }

        public static void GetFiles(InputFileChangeEventArgs e)
        {
            Pages.Index.fileList = e.GetMultipleFiles()
                .Select(rawFile =>
                {
                    var buffer = new byte[rawFile.Size];
                    EncFile file = new EncFile();
                    byte[] key = AES.KeyGen();
                    string keystring = Convert.ToBase64String(key);
                    Console.WriteLine(keystring);
                    ParametersWithIV keyParamsWithIV = AES.GenerateKeyWithIV(key);             
                    rawFile.OpenReadStream().ReadAsync(buffer);
                    file.Description = rawFile.Name;
                    file.RawBytes = AES.Encrypt(buffer, keyParamsWithIV);
                    return file;
                 })
                .ToList();
        }

        public static bool FileSizeIsOK()
        {
            if(Pages.Index.fileList.Count > 0)
            {
                return Pages.Index.fileList[0].RawBytes.Length <= maxFileSize;
            }
            return false;
        }

        //https://docs.microsoft.com/en-us/aspnet/core/blazor/file-uploads?view=aspnetcore-6.0&pivots=webassembly
        public static async Task<HttpResponseMessage> Upload()        {
            try
            {
                return await HttpService.PostAsync("/api/FileInterface/Upload", Pages.Index.fileList);
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                HttpResponseMessage error = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
                return await new Task<HttpResponseMessage>( () => error);
            }
        }

        public static async Task<HttpResponseMessage> Download()
        {
            var x = 5;
            try
            {
                return await HttpService.PostAsync("/api/FileInterface/Download", x);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                HttpResponseMessage error = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
                return await new Task<HttpResponseMessage>( () => error);
            }
        }
      
        public static void Clear()
        {
            Pages.Index.fileList.Clear();
        }
    }
}
