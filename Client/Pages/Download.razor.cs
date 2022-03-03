using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Client.Services;
using Client.Models;
using Microsoft.JSInterop;

namespace Client.Pages
{
    public partial class Download : ComponentBase
    {
        public static DownloadVM FileObj { get; set; } = new DownloadVM();
        EncFile? encFile { get; set; } = null;
        bool isLoading = false;
        public async void OnValidSubmit(EditContext Context)
        {
            isLoading = true;
            StateHasChanged();
            encFile = await HttpService.GetFileAsync(FileObj.FileGUID);
            isLoading = false;
            StateHasChanged();
            string filename = encFile.Description;

            //converting bytes into stream for JS blob
            var fileStream = new MemoryStream(encFile.RawBytes);
            using var streamRef = new DotNetStreamReference(stream: fileStream);

            // Send the data to JS to actually download the file
            await JS.InvokeVoidAsync("SaveFile", filename, streamRef);
        }
    }
}
