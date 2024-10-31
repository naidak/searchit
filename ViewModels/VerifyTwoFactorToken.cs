using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.ViewModels
{
    public class VerifyTwoFactorToken
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
