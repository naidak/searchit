using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kandidat.Dodaj;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JobSearchingWebApp.Endpoints.KandidatSpaseniOglasi.Dodaj
{
    [Authorize(Roles = "Kandidat")]
    [Tags("Kandidat-Spaseni-Oglas")]
    [Route("kandidat-spaseni-oglas-dodaj")]
    public class KandidatSpaseniOglasiDodajEndpoint : MyBaseEndpoint<KandidatSpaseniOglasiDodajRequest, ActionResult<KandidatSpaseniOglasiDodajResponse>>       
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KandidatSpaseniOglasiDodajEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<ActionResult<KandidatSpaseniOglasiDodajResponse>> MyAction(KandidatSpaseniOglasiDodajRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound(new { message = $"Unable to load user with ID {userManager.GetUserId(User)}." });
            }

            var spaseni = dbContext.KandidatSpaseniOglasi.Include(x => x.Oglas)
                                                         .Include(x => x.Kandidat)
                                                         .Where(spaseni => spaseni.KandidatId == request.kandidat_id    
                                                                        && spaseni.Kandidat.IsObrisan == false
                                                                        && spaseni.OglasId == request.oglas_id
                                                                        && spaseni.Oglas.IsObrisan == false)
                                                         .FirstOrDefault(); 

            var oglas = dbContext.Oglasi.Where(oglas => oglas.Id == request.oglas_id 
                                                     && oglas.IsObrisan == false);

            var kandidat = dbContext.Kandidati.Where(kandidat => kandidat.Id == request.kandidat_id 
                                                              && kandidat.IsObrisan == false); 

            if (oglas is null)
            {
                return NotFound(new { message = $"Unable to load job post with ID {request.oglas_id}." });
            }

            if (kandidat is null)
            {
                return NotFound(new { message = $"Unable to load candidate with ID {request.kandidat_id}." });
            }

            var id = 0;

            if (spaseni != null && spaseni.Spasen == true)
            {
                throw new Exception($"Job post has already been saved.");
                //return BadRequest(new { message = $"Job post "}); 
            }

            else if (spaseni != null && spaseni.Spasen == false)
            {
                spaseni.Spasen = true;
            }

            else
            {
                var kandidat_oglas = new Database.KandidatSpaseniOglasi()
                {
                    KandidatId = request.kandidat_id,
                    OglasId = request.oglas_id,
                    Spasen = true
                };

                dbContext.KandidatSpaseniOglasi.Add(kandidat_oglas);

                id = kandidat_oglas.Id;
            }


            await dbContext.SaveChangesAsync();

            return new KandidatSpaseniOglasiDodajResponse { Id = id};
        }
    }
}
