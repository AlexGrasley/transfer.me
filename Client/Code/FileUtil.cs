using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Client.Code
{
    public class FileUtil
    {

        public static string _dragEnterStyle;
        public static IList<string> fileNames = new List<string>();
        public static int numLines;
        private List<IBrowserFile> loadedFiles = new();
        private long maxFileSize = 1024 * 15;
        private int maxAllowedFiles = 3;
        private bool isLoading;

        public static void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            var files = e.GetMultipleFiles();
            fileNames = files.Select(f => f.Name).ToList();
        }

        //Snackbar.configuration.positionclass = defaults.classes.position.topcenter;
        //Snackbar.add($"files with {entries.firstordefault().size} bytes size are not allowed", severity.error);
        //Snackbar.add($"files starting with letter {entries.firstordefault().name.substring(0, 1)} are not recommended", severity.warning);
        //Snackbar.add($"this file has the extension {entries.firstordefault().name.split(".").last()}", severity.info);



        //https://docs.microsoft.com/en-us/aspnet/core/blazor/file-uploads?view=aspnetcore-6.0&pivots=webassembly
        public void Upload(InputFileChangeEventArgs e)
        {
            isLoading = true;
            loadedFiles.Clear();

            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                try
                {
                    loadedFiles.Add(file);
                }
                catch (Exception ex)
                {
                    Snackbar.Equals("Upload Failed", ex);
                }
            }

            isLoading = false;
        }
    }
}
