using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels
{
    public class FileIDInputVM
    {
        [Required]
        public string? FileGUID { get; set; }
    }
}
