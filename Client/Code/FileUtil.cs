using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Client.Code
{
    public static class FileUtil
    {

        public static string _dragEnterStyle;
        public static IList<string> fileNames = new List<string>();
        public static int numLines;

        public static void UploadFiles(InputFileChangeEventArgs e)
        {
            var entries = e.GetMultipleFiles();
            //Do your validations here

            //TODO upload the files to the server
        }

        

        public static void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            var files = e.GetMultipleFiles();
            fileNames = files.Select(f => f.Name).ToList();
        }

        //Snackbar.configuration.positionclass = defaults.classes.position.topcenter;
        //Snackbar.add($"files with {entries.firstordefault().size} bytes size are not allowed", severity.error);
        //Snackbar.add($"files starting with letter {entries.firstordefault().name.substring(0, 1)} are not recommended", severity.warning);
        //Snackbar.add($"this file has the extension {entries.firstordefault().name.split(".").last()}", severity.info);


        public static void Upload()
        {
        ////Upload the files here
        //Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
        //    Snackbar.Add("TODO: Upload your files!", Severity.Normal);
        }
    }
}
