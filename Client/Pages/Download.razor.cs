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
            EncFile file = await HttpService.GetFileAsync("FileUpload");
            byte[] data = file.RawBytes;
            string filename = file.Description;
            MemoryStream stream = new MemoryStream(data);
            StateHasChanged();
        }
    }
}
