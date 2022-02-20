using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Client.Code;

namespace Client.Pages
{
    public partial class SignUp : ComponentBase
    {
        public SignUpVM MySignUpVM { get; set; } = new SignUpVM();
        public async void OnValidSubmit(EditContext context)
        {
            string UserObject = JsonConvert.SerializeObject(context.Model);
            JObject? jo = JObject.Parse(UserObject);
            TransferMeUser UserModel = new Client.Code.TransferMeUser(jo["Username"].ToString(), jo["EmailAddress"].ToString(), jo["Password"].ToString());
            await PushUserDataToServer(UserModel);
            StateHasChanged();
        }
        public async Task PushUserDataToServer(TransferMeUser UserModel)
        {
            HttpClient client = new HttpClient();
            string URL = "https://localhost:44346/";
            await client.PostAsJsonAsync($"{URL}api/UserAuth/createuser", UserModel);
        }
    }
}
