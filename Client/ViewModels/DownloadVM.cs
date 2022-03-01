using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels
{
    public class FileDownloadInputVM
    {
        [Required]
        public string? FileGUID { get; set; }

        [Required]
        public string? Key { get; set; }
    }
}
