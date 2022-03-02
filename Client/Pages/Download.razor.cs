using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Client.Services;
using Client.Models;

namespace Client.Pages
{
    public partial class Download : ComponentBase
    {
        public static FileDownloadInputVM FileObj { get; set; } = new FileDownloadInputVM();
        public async void OnValidSubmit(EditContext Context)
        {
            //Retrieve a file
            //the routing is hardcoded for now            
            EncFile file = await HttpService.GetFileAsync("api/FileDownload/FileID");
            string filename = file.Description;
            MemoryStream stream = new MemoryStream(file.RawBytes);

            //This part doesnt work outside of a razor component yet
            //using var streamRef = new DotNetStreamReference(stream: stream);
            //Send the data to JS to actually download the file
            //await JS.InvokeVoidAsync("SaveFile", filename, streamRef);
            StateHasChanged();
        }
    }
}
