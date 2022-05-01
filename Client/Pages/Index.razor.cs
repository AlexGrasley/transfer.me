using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Client.Services;
using Client.Models;
using MudBlazor;
using MudBlazor.Dialog;

namespace Client.Pages
{
    public partial class Index
    {
        private bool isLoading = false;
        public static IList<EncFile> fileList = new List<EncFile>();
        private bool fileTooLarge = false;
        public static FileDescriptor? fileDescriptor;

        private async void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            fileDescriptor = await FileUtilService.GetFiles(e);
            if (!FileUtilService.FileSizeIsOK())
            {
                fileTooLarge = true;
                StateHasChanged();
            }
            StateHasChanged();
        }

        private async void Upload()
        {
            await FileUtilService.Upload();
            OpenDialog();
            StateHasChanged();
        }

        private void OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            DialogService.Show<Client.Components.FileInfoDialog>("File Information", options);
        }

        private void Clear()
        {
            fileTooLarge = false;
            FileUtilService.Clear();
            StateHasChanged();
        }
    }
}
