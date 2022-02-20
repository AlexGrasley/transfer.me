using Newtonsoft.Json;

namespace Client.ViewModels
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string? ID { get; set; }

        [JsonProperty(PropertyName = "Username")]
        public string? Username { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string? Password { get; set; }

        [JsonProperty(PropertyName = "Email Address")]
        public string? EmailAddress { get; set; }

        public User(string Username, string Password, string EmailAddress)
        {
            this.Username = Username;
            this.Password = Password.GetHashCode().ToString();
            this.EmailAddress = EmailAddress;
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
