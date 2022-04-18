using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Client.Services;
using Client.Models;
using Microsoft.JSInterop;
using Client.Crypto;

namespace Client.Pages
{
    public partial class Download : ComponentBase
    {
        [Parameter]
        public string? FileID { get; set; }
        public static DownloadVM FileObj { get; set; } = new DownloadVM();
        EncFile? encFile { get; set; } = null;
        bool isLoading = false;
        public async void OnValidSubmit(EditContext Context)
        {
            isLoading = true;
            StateHasChanged();
            encFile = await HttpService.GetFileAsync(FileID);
            isLoading = false;
            StateHasChanged();
            string filename = encFile.Description;

            //converting bytes into stream for JS blob
            var fileStream = new MemoryStream(AES.Decrypt(encFile.RawBytes, FileObj.Key));
            using var streamRef = new DotNetStreamReference(stream: fileStream);

            // Send the data to JS to actually download the file
            await JS.InvokeVoidAsync("SaveFile", filename, streamRef);
        }
    }
}
