using Newtonsoft.Json;
using Client.Services;

namespace Client.Models
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
        public string Password { get; set; }

        [JsonProperty(PropertyName = "Email Address")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "Salt")]
        public string? Salt { get; set; }

        public TransferMeUser(string Username, string EmailAddress, string Password)
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
            int iterations = 4000; //times to enc the password
            int saltByteSize = 128; 
            int hashByteSize = 256;

            HashingService hasher = new HashingService();

            byte[] saltBytes = hasher.CreateSalt(saltByteSize);
            string saltString = Convert.ToBase64String(saltBytes);
            Salt = saltString; 
            string pwdHash = hasher.PBKDF2_SHA256_GetHash(Password, saltString, iterations, hashByteSize);
            bool isValid = hasher.ValidatePassword(Password, saltBytes, iterations, hashByteSize, Convert.FromBase64String(pwdHash));
            Password = pwdHash; 
            if (!isValid)
            {
                throw new Exception("Error -- User was not created successfully. Password could not be verified.");
            }
        }
    }
}
