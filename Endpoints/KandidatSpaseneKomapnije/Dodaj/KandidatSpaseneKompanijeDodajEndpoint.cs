using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Endpoints.KandidatSpaseniOglasi.Dodaj;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.KandidatSpaseneKomapnije.Dodaj
{
    [Authorize(Roles = "Kandidat")]
    [Tags("Kandidat-Spasene-Kompanije")]
    [Route("kandidat-spasene-kompanije-dodaj")]
    public class KandidatSpaseneKompanijeDodajEndpoint : MyBaseEndpoint<KandidatSpaseneKompanijeDodajRequest, ActionResult<KandidatSpaseneKompanijeDodajResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KandidatSpaseneKompanijeDodajEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager; 
        }

        [HttpPost]
        public override async Task<ActionResult<KandidatSpaseneKompanijeDodajResponse>> MyAction(KandidatSpaseneKompanijeDodajRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var spaseni = dbContext.KandidatSpaseneKompanije.Include(x => x.Kandidat)
                                                            .Include(x => x.Kompanija)
                                                            .Where(spaseni => spaseni.KandidatId == request.kandidat_id 
                                                                && spaseni.Kandidat.IsObrisan == false
                                                                && spaseni.KompanijaId == request.kompanija_id
                                                                && spaseni.Kompanija.IsObrisan == false)
                                                            .FirstOrDefault();

            var kompanija = dbContext.Kompanije.Where(kompanija => kompanija.Id == request.kompanija_id 
                                                                && kompanija.IsObrisan == false);

            var kandidat = dbContext.Kandidati.Where(kandidat => kandidat.Id == request.kandidat_id 
                                                              && kandidat.IsObrisan == false);

            if (kompanija is null)
            {
                return NotFound($"Unable to load company with ID '{request.kompanija_id}'.");
            }

            if (kandidat is null)
            {
                return NotFound($"Unable to load candidate with ID '{request.kandidat_id}'.");
            }

            var id = 0;

            if (spaseni != null && spaseni.Spasen == true)
            {
                return BadRequest($"Company with ID {request.kompanija_id} has already been saved.");
            }

            else if (spaseni != null && spaseni.Spasen == false)
            {
                spaseni.Spasen = true;
                id = spaseni.Id; 
            }

            else
            {
                var kandidat_kompanija = new Database.KandidatSpaseneKompanije()
                {
                    KandidatId = request.kandidat_id,
                    KompanijaId = request.kompanija_id,
                    Spasen = true
                };

                dbContext.KandidatSpaseneKompanije.Add(kandidat_kompanija);

                id = kandidat_kompanija.Id;
            }

            await dbContext.SaveChangesAsync();

            return new KandidatSpaseneKompanijeDodajResponse { Id = id };
        }
    }
}
