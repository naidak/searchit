using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Endpoints.KandidatOglas.Dodaj;
using JobSearchingWebApp.Helper;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Trunking.V1;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.KompanijaKandidat.Dodaj
{
    [Authorize]
    [Tags("Kompanija-Kandidat")]
    [Route("kompanija-kandidat-dodaj")]
    public class KompanijaKandidatDodajEndpoint : MyBaseEndpoint<KompanijaKandidatDodajRequest, ActionResult<KompanijaKandidatDodajResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KompanijaKandidatDodajEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<ActionResult<KompanijaKandidatDodajResponse>> MyAction(KompanijaKandidatDodajRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var kompanija = dbContext.Kompanije.Where(x => x.Id == request.kompanija_id 
                                                        && x.IsObrisan == false).FirstOrDefault();

            var kandidat = dbContext.Kandidati.Where(x => x.Id == request.kandidat_id 
                                                       && x.IsObrisan == false).FirstOrDefault();

            if(kompanija == null || kompanija.IsObrisan)
            {
                return NotFound($"Unable to load user with ID {request.kompanija_id}.");
            }

            if (kandidat == null || kandidat.IsObrisan)
            {
                return NotFound($"Unable to load user with ID {request.kandidat_id}.");
            }

            var kompanija_kandidat = new KompanijeKandidati()
            {
                KompanijaId = request.kompanija_id,
                KandidatId = request.kandidat_id,
                DatumRazgovora = request.datum_razgovora,    
            };

            dbContext.KompanijeKandidati.Add(kompanija_kandidat);
            await dbContext.SaveChangesAsync();

            return new KompanijaKandidatDodajResponse { Id = kompanija_kandidat.Id };
        }
    }
}
