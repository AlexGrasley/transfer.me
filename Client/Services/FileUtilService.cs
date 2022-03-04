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

        public static async Task<FileDescriptor> GetFiles(InputFileChangeEventArgs e)
        {
            EncFile file = new EncFile();
            byte[] key = AES.KeyGen();
            string keystring = Convert.ToBase64String(key);
            ParametersWithIV keyParamsWithIV = AES.GenerateKeyWithIV(key);
            if (e.File != null)
            {
                var buffer = new byte[e.File.Size];
                await e.File.OpenReadStream().ReadAsync(buffer, 0, buffer.Length);
                file.Description = e.File.Name;
                file.RawBytes = AES.Encrypt(buffer, keyParamsWithIV);
                Pages.Index.fileList.Add(file);
            }
            FileDescriptor fileDescriptor = new FileDescriptor() { FileID = file.FileID, Key = keystring };
            return fileDescriptor;
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
                return await HttpService.PostAsync("/api/FileInterface/Upload", Pages.Index.fileList); ;    
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                HttpResponseMessage error = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
                return await new Task<HttpResponseMessage>( () => error);
            }
            finally
            {
                Clear();  
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
