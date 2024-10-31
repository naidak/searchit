using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.ViewModels;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.Delete
{
    [Authorize]
    [Tags("Korisnik-Notifikacija")]
    [Route("korisnik-notifikacija-delete")]
    public class KorisnikNotifikacijaDeleteEndpoint : MyBaseEndpoint<KorisnikNotifikacijaDeleteRequest, ActionResult<NoResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KorisnikNotifikacijaDeleteEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpDelete]
        public override async Task<ActionResult<NoResponse>> MyAction([FromQuery] KorisnikNotifikacijaDeleteRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var korisnik_notifikacija = dbContext.KorisnikNotifikacije.Include(x => x.Korisnik)
                                                                      .Where(x => x.Id == request.korisnik_notifikacija_id 
                                                                                && x.Korisnik.IsObrisan == false)
                                                                      .FirstOrDefault();

            if (korisnik_notifikacija == null)
            {
                return NotFound($"Unable to load notification with ID {request.korisnik_notifikacija_id}.");
            }

            dbContext.Remove(korisnik_notifikacija);
            await dbContext.SaveChangesAsync();

            return new NoResponse() { };
        }
    }
}
