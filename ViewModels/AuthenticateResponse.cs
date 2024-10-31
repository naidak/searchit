using JobSearchingWebApp.Database;

namespace JobSearchingWebApp.ViewModels
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public int UlogaId { get; set; }

        public string Token { get; set; }


        public AuthenticateResponse(Korisnik korisnik, string token)
        {
            Id = korisnik.Id;
            Email = korisnik.Email;
            Username = korisnik.UserName;
            UlogaId = korisnik.UlogaId;
            Token = token;
        }
    }
}
