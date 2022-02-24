using Newtonsoft.Json;

namespace Client.Code
{
    public class TransferMeUser
    {
        [JsonProperty(PropertyName = "id")]
        public string? ID { get; set; }

        [JsonProperty(PropertyName = "UserID")]
        public string? UserID { get; set; }

        [JsonProperty(PropertyName = "Username")]
        public string? Username { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string? Password { get; set; }

        [JsonProperty(PropertyName = "Email Address")]
        public string? EmailAddress { get; set; }

        public TransferMeUser(string Username, string EmailAddress, string Password)
        {
            this.Username = Username;
            this.Password = Password.GetHashCode().ToString();
            this.EmailAddress = EmailAddress;
            ID = Guid.NewGuid().ToString();
            UserID = ID;
        }
    }
}
