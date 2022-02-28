using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Client.Services;
using Client.Models;

namespace Client.Pages
{
    public partial class SignUp : ComponentBase
    {
        public SignUpVM MySignUpVM { get; set; } = new SignUpVM();
        public async void OnValidSubmit(EditContext Context)
        { 
            TransferMeUser UserModel = new TransferMeUser(MySignUpVM.Username, MySignUpVM.EmailAddress, MySignUpVM.Password);
            HttpService wc = new HttpService();
            await HttpService.PostAsync("api/UserAuth/createuser", UserModel);
            StateHasChanged();
        }
    }
}
