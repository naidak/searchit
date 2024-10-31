using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.ViewModels
{
    public class ConfirmEmail
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
