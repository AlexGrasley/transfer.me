using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Client.Services;
using Client.Models;

namespace Client.Pages
{
    public partial class SignUp : ComponentBase
    {
        public SignUpVM MySignUpVM { get; set; } = new SignUpVM();
        public async void OnValidSubmit(EditContext context)
        { 
            JObject? jo = JObject.Parse((JsonConvert.SerializeObject(context.Model)));
            TransferMeUser UserModel = new TransferMeUser(jo["Username"].ToString(), jo["EmailAddress"].ToString(), jo["Password"].ToString());
            HttpService wc = new HttpService();
            await HttpService.PostAsync("api/UserAuth/createuser", UserModel);
            StateHasChanged();
        }
    }
}
