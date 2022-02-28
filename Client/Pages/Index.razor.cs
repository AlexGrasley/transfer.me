using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Client.Services;
using Client.Models;

namespace Client.Pages
{
    public partial class Index
    {
        private bool isLoading = false;
        public static IList<EncFile> fileList = new List<EncFile>();
        private bool fileTooLarge = false;

        private void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            isLoading = true;
            StateHasChanged();
            FileUtilService.GetFiles(e);
            isLoading = false;
            StateHasChanged();
            if (!FileUtilService.FileSizeIsOK())
            {
                fileTooLarge = true;
                StateHasChanged();
            }
        }

        private void Clear()
        {
            fileTooLarge = false;
            FileUtilService.Clear();
            StateHasChanged();
        }
    }
}
