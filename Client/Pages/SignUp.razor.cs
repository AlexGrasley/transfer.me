using Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Client.Pages
{
    public partial class SignUp : ComponentBase
    {
        public SignUpVM MySignUpVM { get; set; } = new SignUpVM();
        public async void OnValidSubmit(EditContext context)
        {
            string UserObject = JsonConvert.SerializeObject(context.Model);
            JObject? jo = JObject.Parse(UserObject);
            User UserModel = new User(jo["Username"].ToString(), jo["Emmail Address"].ToString(), jo["Password"].ToString());
            await PushUserDataToServer(UserModel);
            StateHasChanged();
        }
        private async Task PushUserDataToServer(User UserModel)
        {
            string url = "https://localhost7154/api/createuser";
            HttpClient client = new HttpClient();
            //var UserData = new StringContent(UserModel, Encoding.UTF8, "application/json");
            var result = await client.PostAsJsonAsync(url, UserModel);
        }
    }
}
