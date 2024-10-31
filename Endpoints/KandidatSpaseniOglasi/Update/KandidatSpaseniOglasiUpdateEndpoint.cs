using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Endpoints.KandidatSpaseniOglasi.Dodaj;
using JobSearchingWebApp.Endpoints.Oglas.Update;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.KandidatSpaseniOglasi.Update
{
    [Authorize(Roles = "Kandidat")]
    [Tags("Kandidat-Spaseni-Oglas")]
    [Route("kandidat-spaseni-oglas-update")]
    public class KandidatSpaseniOglasiUpdateEndpoint : MyBaseEndpoint<KandidatSpaseniOglasiUpdateRequest, ActionResult<KandidatSpaseniOglasiUpdateResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KandidatSpaseniOglasiUpdateEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPatch]
        public override async Task<ActionResult<KandidatSpaseniOglasiUpdateResponse>> MyAction(KandidatSpaseniOglasiUpdateRequest request, CancellationToken cancellationToken)
        { 
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var spaseni = dbContext.KandidatSpaseniOglasi.Include(x => x.Kandidat)
                                                         .Include(x => x.Oglas)
                                                         .Where(spaseni => spaseni.KandidatId == request.kandidat_id 
                                                                        && spaseni.OglasId == request.oglas_id
                                                                        && spaseni.Kandidat.IsObrisan == false
                                                                        && spaseni.Oglas.IsObrisan == false)
                                                         .FirstOrDefault();

            if (spaseni == null)
            {
                return NotFound($"Unable to load job post with ID {request.oglas_id}.");
            }

            spaseni.Spasen = false; 

            await dbContext.SaveChangesAsync();

            return new KandidatSpaseniOglasiUpdateResponse { id = spaseni.Id };
        }
    }
}
