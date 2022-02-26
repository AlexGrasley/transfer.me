using Newtonsoft.Json;

namespace Shared.Models
{
    public class SignInRequest
    {
        [JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        public SignInRequest(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password.GetHashCode().ToString();
        }
    }
}
