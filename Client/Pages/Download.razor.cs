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
            await HttpService.PostAsync("api/FileInterface/Download", FileObj);
            await DownloadFile();
            StateHasChanged();
        }
    }
}
