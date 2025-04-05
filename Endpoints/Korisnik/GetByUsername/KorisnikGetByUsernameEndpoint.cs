using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.Korisnik.GetByUsername
{  
    [Tags("Korisnik")]
    [Route("get-by-username")]
    [AllowAnonymous]
    public class KorisnikGetByUsernameEndpoint : MyBaseEndpoint<KorisnikGetByUsernameRequest, KorisnikGetByUsernameResponse>
    {
        private readonly Data.ApplicationDbContext _context;
        public KorisnikGetByUsernameEndpoint(Data.ApplicationDbContext context)
        {
            _context = context;
        }
      
        [HttpGet]
        public override async Task<KorisnikGetByUsernameResponse> MyAction([FromQuery]KorisnikGetByUsernameRequest request, CancellationToken cancellationToken)
        {
            var list =await _context.Korisnici.Where(x => x.UserName == request.username).ToListAsync();

            var korisnik_id = list.FirstOrDefault().Id ?? "";

            return new KorisnikGetByUsernameResponse { user_id =  korisnik_id };
        }
    }
}
