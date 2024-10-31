using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Helper;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.GetAll
{
    [Authorize]
    [Tags("Korisnik-Notifikacija")]
    [Route("korisnik-notifikacija-get-all")]
    public class KorisnikNotifikacijaGetAllEndpoint : MyBaseEndpoint<KorisnikNotifikacijaGetAllRequest, ActionResult<KorisnikNotifikacijaGetAllResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KorisnikNotifikacijaGetAllEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<KorisnikNotifikacijaGetAllResponse>> MyAction([FromQuery] KorisnikNotifikacijaGetAllRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if (userId == request.korisnik_id)
            {
                var korisnici_notifikacije = await dbContext
                            .KorisnikNotifikacije
                            .Where(x => (request.korisnik_id == null || x.KorisnikId == request.korisnik_id)
                                     && (request.notifikacija_id == null || x.NotifikacijaId == request.notifikacija_id)
                                     && (request.datum_primanja == null || x.DatumPrimanja == request.datum_primanja)
                                     && (request.pogledano == null || x.Pogledano == request.pogledano))
                            .Select(x => new KorisniciNotifikacijeGetAllResponse()
                            {
                                KorisnikId = x.KorisnikId,
                                NotifikacijaId = x.NotifikacijaId,
                                DatumPrimanja = x.DatumPrimanja,
                                Pogledano = x.Pogledano
                            }).ToListAsync();

                return new KorisnikNotifikacijaGetAllResponse { KorisniciNotifikacije = korisnici_notifikacije };
            }

            else return Unauthorized(); 
        }
    }
}
