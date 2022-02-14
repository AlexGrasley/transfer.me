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
            jo.Property("ConfPassword").Remove();
            UserObject = jo.ToString();
            await PushUserDataToServer(UserObject);
            StateHasChanged();
        }
        private async Task PushUserDataToServer(string JSONData)
        {
            string url = "https://localhost7154/api/createuser";
            HttpClient client = new HttpClient();
            var UserData = new StringContent(JSONData, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, UserData);
        }
    }
}
