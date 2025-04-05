using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Oglas.GetById;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.CV.GetById
{
    //[Authorize]
    [AllowAnonymous]
    [Tags("CV")]
    [Route("cv/get-by-id")]
    public class CVGetByIdEndpoint : MyBaseEndpoint<int, CVGetByIdResponse>
    {
        private readonly ApplicationDbContext dbContext;

        public CVGetByIdEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public override async Task<CVGetByIdResponse> MyAction(int id, CancellationToken cancellationToken)
        {
            var cv = dbContext.CV.Include(x => x.Kandidat).Where(x => x.Id == id && x.Kandidat.IsObrisan == false).FirstOrDefault();

            if (cv == null)
                throw new Exception("Ne postoji cv sa ID " + id);

            var cvResponse = new CVGetByIdResponse
            {
                Id = cv.Id,
                Naziv = cv.Naziv,
                KandidatId = cv.KandidatId,
                Objavljen = cv.Objavljen,
                Ime = cv.Ime,
                Prezime = cv.Prezime,
                Email = cv.Email,
                PhoneNumber = cv.PhoneNumber,
                Grad = cv.Grad,
                Drzava = cv.Drzava,
                ProfesionalniSazetak = cv.ProfesionalniSazetak, 
                DatumModificiranja = cv.DatumModificiranja,
                Kursevi = cv.Kursevi,   
                Vjestine = cv.Vjestine, 
                TehnickeVjestine = cv.TehnickeVjestine,
                Edukacija = dbContext.CVEdukacija.Where(x => x.CVId == id).Include(x => x.Edukacija).Select(e => new EdukacijaResponse
                {
                    Id = e.EdukacijaId,
                    NazivSkole = e.Edukacija.NazivSkole, 
                    DatumPocetka = e.Edukacija.DatumPocetka, 
                    DatumZavrsetka = e.Edukacija.DatumZavrsetka, 
                    Grad = e.Edukacija.Grad,
                    Opis = e.Edukacija.Opis
                }).ToList(),
                Zaposlenje = dbContext.CVZaposlenje.Where(x => x.CVId == id).Include(x => x.Zaposlenje).Select(z => new ZaposlenjeResponse
                {
                    Id = z.ZaposlenjeId,
                    NazivKompanije = z.Zaposlenje.NazivKompanije,
                    NazivPozicije = z.Zaposlenje.NazivPozicije, 
                    DatumPocetka = z.Zaposlenje.DatumPocetka, 
                    DatumZavrsetka = z.Zaposlenje.DatumZavrsetka,
                    Opis = z.Zaposlenje.Opis
                }).ToList(),
                URL = dbContext.CVURL.Where(x => x.CVId == id).Include(x => x.URL).Select(u => new URLResponse
                {
                   Id = u.URLId,
                   Naziv = u.URL.Naziv,
                   Putanja = u.URL.Putanja,
                }).ToList(),
            };

            return cvResponse;
        }
    }
}
