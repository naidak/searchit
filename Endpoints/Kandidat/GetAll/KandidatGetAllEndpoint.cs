using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Kandidat.GetAll
{
    [Authorize(Roles = "Admin")]
    [Tags("Kandidat")]
    [Route("kandidat-get")]
    public class KandidatGetAllEndpoint : MyBaseEndpoint<KandidatGetAllRequest, ActionResult<KandidatGetAllResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KandidatGetAllEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<KandidatGetAllResponse>> MyAction([FromQuery] KandidatGetAllRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return BadRequest(new { message = $"User with doesn't exist." });
            }

            var kandidati = await dbContext
                                 .Kandidati
                                 .Where(x => (request.Ime == null || x.Ime.ToLower().StartsWith(request.Ime.ToLower())) 
                                          && (request.Prezime == null || x.Prezime.ToLower().StartsWith(request.Prezime.ToLower()))
                                          && (request.Username == null || x.UserName.ToLower().StartsWith(request.Username.ToLower()))
                                          && x.IsObrisan == false)
                                 .Select(x => new KandidatiGetAllResponse()
                                 {
                                     Id = x.Id,   
                                     Email = x.Email,
                                     Username = x.UserName,   
                                     Ime = x.Ime,
                                     Prezime = x.Prezime,    
                                     DatumRodjenja = x.DatumRodjenja, 
                                     MjestoPrebivalista = x.MjestoPrebivalista,
                                     Zvanje = x.Zvanje
                                 }).ToListAsync();    

            return new KandidatGetAllResponse { Kandidati = kandidati };   
        }
    }
}
