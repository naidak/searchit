using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kandidat.Update;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;

namespace JobSearchingWebApp.Endpoints.KandidatOglas.Update
{
    [Authorize]
    [Tags("Kandidat-Oglas")]
    [Route("kandidat-oglas-update")]
    public class KandidatOglasUpdateEndpoint : MyBaseEndpoint<KandidatOglasUpdateRequest, ActionResult<KandidatOglasUpdateResponse>>
    {
        private readonly ApplicationDbContext dbContext;

        public KandidatOglasUpdateEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPut]
        public override async Task<ActionResult<KandidatOglasUpdateResponse>> MyAction(KandidatOglasUpdateRequest request, CancellationToken cancellationToken)
        {
            var kandidat_oglas = dbContext.KandidatiOglasi.Where(x => x.Id == request.Id 
                                                                   && x.KandidatId == request.KandidatId 
                                                                   && x.Kandidat.IsObrisan == false
                                                                   && x.Oglas.KompanijaId == request.KompanijaId 
                                                                   && x.Oglas.Kompanija.IsObrisan == false
                                                                   && x.Oglas.IsObrisan == false)
                                                          .Include(x => x.Oglas)
                                                          .ThenInclude(x => x.Kompanija) 
                                                          .Include(x => x.Kandidat)
                                                          .FirstOrDefault();

            if (kandidat_oglas == null)
            {
                return NotFound($"Unable to load application with ID '{request.Id}'.");
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                kandidat_oglas.Status = request.Status;
            }

            if (request.Spasen != null)
            {
                kandidat_oglas.Spasen = (bool)request.Spasen;
            }

            await dbContext.SaveChangesAsync();

            return new KandidatOglasUpdateResponse { Id = kandidat_oglas.Id };
        }
    }
}
