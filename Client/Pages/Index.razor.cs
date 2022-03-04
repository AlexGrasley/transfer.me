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
        private FileDescriptor? fileDescriptor;
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

        private void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            isLoading = true;
            StateHasChanged();
            fileDescriptor = FileUtilService.GetFiles(e);
            isLoading = false;
            StateHasChanged();
            if (!FileUtilService.FileSizeIsOK())
            {
                fileTooLarge = true;
                StateHasChanged();
            }
        }

        private DialogService GetDialogService()
        {
            return DialogService;
        }

        private void OpenDialog(DialogService dialogService)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            IDialogReference dialogReference = dialogService.Show<MudDialog>("Simple Dialog", options);
        }

        private void Clear()
        {
            fileTooLarge = false;
            FileUtilService.Clear();
            StateHasChanged();
        }
    }
}
