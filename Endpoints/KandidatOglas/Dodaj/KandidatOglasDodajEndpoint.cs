using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kandidat.Dodaj;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.KandidatOglas.Dodaj
{
    [Authorize(Roles = "Kandidat")]
    [Tags("Kandidat-Oglas")]
    [Route("kandidat-oglas-dodaj")]
    public class KandidatOglasDodajEndpoint : MyBaseEndpoint<KandidatOglasDodajRequest, ActionResult<KandidatOglasDodajResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KandidatOglasDodajEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<ActionResult<KandidatOglasDodajResponse>> MyAction(KandidatOglasDodajRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return BadRequest(new { message = $"User with ID {request.KandidatId} doesn't exist." });
            }

            if (request.KandidatId == userId)
            {
                var kandidatOglas = dbContext.KandidatiOglasi.Include(x => x.Kandidat)
                                                             .Where(x => x.OglasId == request.OglasId 
                                                                      && x.KandidatId == request.KandidatId
                                                                      && x.Kandidat.IsObrisan == false)
                                                             .FirstOrDefault();

                if (kandidatOglas != null)
                {
                    return BadRequest(new { message = "You have already applied for this post." });
                }

                var status = StatusPrijaveExtensions.GetAllStatusPrijave().Where(x => x == "No status").FirstOrDefault();

                var kandidat_oglas = new KandidatiOglasi()
                {
                    KandidatId = request.KandidatId,
                    OglasId = request.OglasId,
                    CVId = request.CVId,
                    DatumPrijave = request.DatumPrijave,
                    Status = status!
                };

                dbContext.KandidatiOglasi.Add(kandidat_oglas);
                await dbContext.SaveChangesAsync();

                return new KandidatOglasDodajResponse { Id = kandidat_oglas.Id };
            }

            else return Unauthorized(); 
        }
    }
}
