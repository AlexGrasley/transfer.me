using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shared.Models
{
    public class EncFile
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        /// <summary>
        /// Unique ID for file. This gets set when creating EncFile constructor. 
        /// </summary>
        /// [JsonProperty(PropertyName = "FileID")]
        [JsonProperty(PropertyName = "FileID")]
        public string FileID { get; set; }

        /// <summary>
        /// Unique ID for sending User. FK to User table.
        /// </summary>
        [JsonProperty(PropertyName = "UserIDFrom")]
        public long UserIDFrom { get; set; }

        /// <summary>
        /// Unique ID for recieving User. FK to User table.
        /// </summary>
        [JsonProperty(PropertyName = "UserIDTo")]
        public long UserIDTo { get; set; }

        /// <summary>
        /// Name of the file. Should match the file name including extension. Not user editable.
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Actual bytes of the file. Should be encrypted before it gets set here.
        /// </summary>
        [JsonProperty(PropertyName = "RawBytes")]
        public byte[] RawBytes { get; set; }

        private const long DEFAULT_DATA_SIZE = 2048;

        /// <summary>
        /// default constructor needed because Description and RawBytes cannot be null. RawBytes and Description should be set appropriately when creating a file.
        /// </summary>
        public EncFile()
        {
            FileID = Guid.NewGuid().ToString(); //New Guid() was calling the default constructor 
            ID = FileID;
            Description = "";
            RawBytes = new byte[DEFAULT_DATA_SIZE];
        }
    }
}
