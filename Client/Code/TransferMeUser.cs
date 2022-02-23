using Newtonsoft.Json;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using System.Text;

namespace Client.Code
{
    public class TransferMeUser
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "UserID")]
        public string UserID { get; set; }

        [JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public byte[] Password { get; set; }

        [JsonProperty(PropertyName = "Email Address")]
        public string EmailAddress { get; set; }

        public TransferMeUser(string Username, string EmailAddress, byte[] Password)
        {
            this.Username = Username;
            this.Password = Password;
            HashPassword();
            this.EmailAddress = EmailAddress;
            ID = Guid.NewGuid().ToString();
            UserID = ID;
        }

        public void HashPassword()
        {
            string HashedBytes = BCrypt.Net.BCrypt.HashPassword(Encoding.UTF8.GetString(Password, 0, Password.Length));
            Password = Encoding.UTF8.GetBytes(HashedBytes);
        }
    }
}
