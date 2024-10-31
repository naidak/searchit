using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.Update
{
    [Authorize]
    [Tags("Korisnik-Notifikacija")]
    [Route("korisnik-notifikacija-update")]
    public class KorisnikNotifikacijaUpdateEndpoint : MyBaseEndpoint<KorisnikNotifikacijaUpdateRequest, ActionResult<KorisnikNotifikacijaUpdateResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;


        public KorisnikNotifikacijaUpdateEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPatch]
        public override async Task<ActionResult<KorisnikNotifikacijaUpdateResponse>> MyAction(KorisnikNotifikacijaUpdateRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID {userManager.GetUserId(User)}.");
            }

            var korisnik_notifikacija = dbContext.KorisnikNotifikacije.Include(x => x.Korisnik)
                                                                      .Where(x => x.Id == request.korisnik_notifikacija_id
                                                                               && x.Korisnik.IsObrisan == false ) 
                                                                      .FirstOrDefault();

            if (korisnik_notifikacija == null)
            {
                return NotFound($"Unable to load notification with ID {request.korisnik_notifikacija_id}.");
            }

            korisnik_notifikacija.Pogledano = request.pogledano;

            await dbContext.SaveChangesAsync();

            return new KorisnikNotifikacijaUpdateResponse { Id = korisnik_notifikacija.Id };
        }
    }
}
