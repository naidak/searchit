using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.KandidatSpaseniOglasi.Update;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JobSearchingWebApp.Endpoints.KandidatSpaseneKomapnije.Update
{
    [Authorize(Roles = "Kandidat")]
    [Tags("Kandidat-Spasene-Kompanije")]
    [Route("kandidat-spasene-kompanije-update")]
    public class KandidatSpaseneKompanijeUpdateEndpoint : MyBaseEndpoint<KandidatSpaseneKompanijeUpdateRequest, ActionResult<KandidatSpaseneKompanijeUpdateResponse>>
    {
        private readonly ApplicationDbContext dbContext;

        public KandidatSpaseneKompanijeUpdateEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPatch]
        public override async Task<ActionResult<KandidatSpaseneKompanijeUpdateResponse>> MyAction(KandidatSpaseneKompanijeUpdateRequest request, CancellationToken cancellationToken)
        {
            var spaseni = dbContext.KandidatSpaseneKompanije.Include(x => x.Kandidat)
                                                            .Include(x => x.Kompanija)
                                                            .Where(spaseni => spaseni.KandidatId == request.kandidat_id
                                                                && spaseni.Kandidat.IsObrisan == false
                                                                && spaseni.KompanijaId == request.kompanija_id
                                                                && spaseni.Kompanija.IsObrisan == false)
                                                            .FirstOrDefault();

            if (spaseni == null)
            {
                return NotFound($"Unable to load saved company with ID {request.kompanija_id}.");
            }

            spaseni.Spasen = request.Spasen;

            await dbContext.SaveChangesAsync();

            return new KandidatSpaseneKompanijeUpdateResponse { id = spaseni.Id };
        }
    }
}
