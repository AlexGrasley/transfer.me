﻿using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Net.Http.Json;

namespace Client.Code
{
    public static class FileUtil
    {

        public static string _dragEnterStyle;
        public static IList<string> fileNames = new List<string>();
        public static IList<EncFile> fileList = new List<EncFile>();
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


        public static void Upload()
        {
            HttpClient client = new HttpClient();
            client.PostAsJsonAsync("/api/FileInterface/Upload", fileList);
        ////Upload the files here
        //Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
        //    Snackbar.Add("TODO: Upload your files!", Severity.Normal);
        }
    }
}
