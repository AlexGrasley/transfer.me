using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Client.Services;

namespace Client.Pages
{
    public partial class GetFileTest : ComponentBase
    {
        public static FileIDInputVM FileObj { get; set; } = new FileIDInputVM();
        public async void OnValidSubmit(EditContext Context)
        {
            HttpService wc = new HttpService();
            await HttpService.PostAsync("api/FileUtil/download", FileObj.FileGUID);
            StateHasChanged();
        }
    }
}
