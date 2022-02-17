using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Net.Http.Json;

namespace Client.Code
{
    public class FileUtil
    {

        public static string _dragEnterStyle;
        public static IList<string> fileNames = new List<string>();
        public static IList<EncFile> fileList = new List<EncFile>();
        public static int numLines;
        private List<IBrowserFile> loadedFiles = new();
        private long maxFileSize = 1024 * 15;
        private int maxAllowedFiles = 3;
        private bool isLoading;

        public static void OnInputFileChanged(InputFileChangeEventArgs e)
        { 
            var files = e.GetMultipleFiles();
            fileNames = files.Select(f => f.Name).ToList();
            foreach (var file in files)
            {
                var buffers = new byte[file.Size];
                var content = file.OpenReadStream().ReadAsync(buffers);
                var saveFile = new EncFile
                {
                    Description = file.Name,
                    RawBytes = buffers
                };
                fileList.Add(saveFile);
            }
        }

        //Snackbar.configuration.positionclass = defaults.classes.position.topcenter;
        //Snackbar.add($"files with {entries.firstordefault().size} bytes size are not allowed", severity.error);
        //Snackbar.add($"files starting with letter {entries.firstordefault().name.substring(0, 1)} are not recommended", severity.warning);
        //Snackbar.add($"this file has the extension {entries.firstordefault().name.split(".").last()}", severity.info);



        //https://docs.microsoft.com/en-us/aspnet/core/blazor/file-uploads?view=aspnetcore-6.0&pivots=webassembly
        public void Upload()
        {
            string URL = "https://localhost:44346/";
            HttpClient client = new HttpClient();
            client.PostAsJsonAsync($"{URL}api/FileInterface/Upload", fileList);
        ////Upload the files here
        //Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
        //    Snackbar.Add("TODO: Upload your files!", Severity.Normal);
        }
        public static void Clear()
        {
            fileList.Clear();
            fileNames.Clear();
        }
    }
}
