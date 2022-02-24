﻿using Newtonsoft.Json;

namespace Shared.Models;
    public class TransferMeUser
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "UserID")]
        public string? UserID { get; set; }

        [JsonProperty(PropertyName = "Username")]
        public string? Username { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string? Password { get; set; }

        [JsonProperty(PropertyName = "Email Address")]
        public string? EmailAddress { get; set; }

        [JsonProperty(PropertyName = "Salt")]
        public string? Salt { get; set; }
    }
