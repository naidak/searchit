using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MapsterMapper;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.Dodaj
{
    [Authorize]
    [Tags("Korisnik-Notifikacija")]
    [Route("korisnik-notifikacija-dodaj")]
    public class KorisnikNotifikacijaDodajEndpoint : MyBaseEndpoint<KorisnikNotifikacijaDodajRequest, ActionResult<KorisnikNotifikacijaDodajResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KorisnikNotifikacijaDodajEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<ActionResult<KorisnikNotifikacijaDodajResponse>> MyAction(KorisnikNotifikacijaDodajRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if(userId == request.korisnik_id)
            {
                var korisnik_notifikacija = new KorisnikNotifikacije()
                {
                    KorisnikId = request.korisnik_id,
                    NotifikacijaId = request.notifikacija_id,
                    DatumPrimanja = request.datum_primanja,
                    Pogledano = request.pogledano
                };

                dbContext.KorisnikNotifikacije.Add(korisnik_notifikacija);
                await dbContext.SaveChangesAsync();

                return new KorisnikNotifikacijaDodajResponse { Id = korisnik_notifikacija.Id };
            }
    
            else return Unauthorized();
        }
    }
}
