using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Me.Shared.Models
{
    public class EncryptedFile
    {
        public long FileID { get; set; }
	    public long FileSize { get; set; }
        public string Descript { get; set; }
        public byte[] FileData { get; set; }
        public long UserID { get; set; }
    }
}
