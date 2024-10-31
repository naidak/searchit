using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.KompanijaKandidat.GetAll
{
    [Authorize]
    [Tags("Kompanija-Kandidat")]
    [Route("kompanija-kandidat-get-all")]
    public class KompanijaKandidatGetAllEndpoint : MyBaseEndpoint<KompanijaKandidatGetAllRequest, ActionResult<KompanijaKandidatGetAllResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KompanijaKandidatGetAllEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<KompanijaKandidatGetAllResponse>> MyAction([FromQuery] KompanijaKandidatGetAllRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var kompanija_kandidat = await dbContext
                                .KompanijeKandidati
                                .Where(x => (request.kandidat_id == null || x.KandidatId == request.kandidat_id)
                                         && (request.kompanija_id == null || x.KompanijaId == request.kompanija_id)
                                         && (request.datum_razgovora == null || x.DatumRazgovora == request.datum_razgovora))
                                .Include(x => x.Kompanija)
                                .Include(x => x.Kandidat)
                                .Select(x => new KompanijeKandidatiGetAllResponse()
                                {
                                    KandidatId = x.KandidatId,
                                    KompanijaId = x.Kompanija.Id,
                                    DatumRazgovora = x.DatumRazgovora,  
                                }).ToListAsync();

            return new KompanijaKandidatGetAllResponse { KompanijeKandidati = kompanija_kandidat };
        }
    }
}
