using Org.BouncyCastle.Crypto.Parameters;

namespace Client.Models
{
    public class FileDescriptor
    {

        public string? FileID { get; set; }
        public ParametersWithIV? Key { get; set; }

    }
}
