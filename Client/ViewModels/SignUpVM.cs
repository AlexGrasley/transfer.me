using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels
{
    public class SignUpVM
    {
        [Required]
        [StringLength(12, ErrorMessage = "Name length can't be more than 12.")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 12 characters long.", MinimumLength = 12)]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string? ConfPassword { get; set; }
    }
}
