using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Oglas.GetAll;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace JobSearchingWebApp.Endpoints.CV.GetAll
{
    [Authorize]
    [Tags("CV")]
    [Route("cv-get")]
    public class CVGetAllEndpoint : MyBaseEndpoint<CVGetAllRequest, CVGetAllResponse>
    {
        private readonly ApplicationDbContext dbContext;

        public CVGetAllEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public override async Task<CVGetAllResponse> MyAction([FromQuery] CVGetAllRequest request, CancellationToken cancellationToken)
        {
            var cv = dbContext.CV.Include(x => x.Kandidat).Where(x => x.Kandidat.IsObrisan == false).AsQueryable();


            if (!string.IsNullOrEmpty(request.KandidatId))
            {
                cv = cv.Where(cv => cv.KandidatId == request.KandidatId);
            }

            if (request.Objavljen != null)
            {
                cv = cv.Where(cv => cv.Objavljen == request.Objavljen);
            }

            if (!string.IsNullOrEmpty(request.Naziv))
            {
                cv = cv.Where(cv => cv.Naziv.ToLower().Contains(request.Naziv.ToLower()));
            }

            var lista = cv.Select(cv => new CVGetAllResponseCV
            {
                Id = cv.Id,
                Naziv = cv.Naziv,
                Objavljen = cv.Objavljen,
                Ime = cv.Ime,
                Prezime = cv.Prezime,
                Zvanje = cv.Kandidat.Zvanje,
                Email = cv.Email,
                PhoneNumber = cv.PhoneNumber,
                Grad = cv.Grad,
                Drzava = cv.Drzava,
                ProfesionalniSazetak = cv.ProfesionalniSazetak,
                DatumModificiranja = cv.DatumModificiranja
            }).ToList();

            return new CVGetAllResponse { CV = lista };
        }
    }
}
