using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Oglas.GetById
{
    [AllowAnonymous]
    [Tags("Oglas")]
    [Route("oglas/get-by-id")]
    public class OglasGetByIdEndpoint : MyBaseEndpoint<int, ActionResult<OglasGetByIdResponse>>
    {
        private readonly ApplicationDbContext dbContext;

        public OglasGetByIdEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<OglasGetByIdResponse>> MyAction(int id, CancellationToken cancellationToken)
        {
            var oglas = dbContext.Oglasi.Include(kompanija => kompanija.Kompanija)
                                        .Where(x => x.Id == id
                                                 && x.Kompanija.IsObrisan == false
                                                 && x.IsObrisan == false)
                                        .FirstOrDefault();  

            var opis = dbContext.OpisOglas.Where(x => x.OglasId == id).FirstOrDefault();  

            if (oglas == null || oglas.IsObrisan == true)
            {
                return NotFound($"Unable to load job post with ID {id}.");
            }

            var oglasOpis = new OglasGetByIdResponse
            {
                Id = oglas.Id,
                KompanijaNaziv = oglas.Kompanija.Naziv,
                Logo = oglas.Kompanija!.Logo != null ? Convert.ToBase64String(oglas.Kompanija!.Logo) : null,
                KompanijaId = oglas.Kompanija.Id, 
                NazivPozicije = oglas.NazivPozicije,
                DatumObjave = oglas.DatumObjave,
                Plata = oglas.Plata,
                TipPosla = oglas.TipPosla,
                RokPrijave = oglas.RokPrijave,
                DatumModificiranja = oglas.DatumModificiranja,
                Lokacija = dbContext.OglasLokacija.Where(x => x.OglasId == id).Select(l => new OglasGetByIdResponseOglasLokacija
                {
                    Id = l.LokacijaId,
                    Naziv = l.Lokacija.Naziv,
                }).ToList(),
                Iskustvo = dbContext.OglasIskustvo.Where(x => x.OglasId == id).Select(l => new OglasGetByIdResponseOglasIskustvo
                {
                    Id = l.IskustvoId,
                    Naziv = l.Iskustvo.Naziv,
                }).ToList(),
                OpisOglasa = new OglasGetByIdResponseOpisOglasa
                {
                    OpisPozicije = opis == null ? " " : opis.OpisPozicije,
                    Kvalifikacija = opis?.Kvalifikacija,
                    Vjestine = opis?.Vjestine,
                    Benefiti = opis?.Benefiti,
                    MinimumGodinaIskustva = opis?.MinimumGodinaIskustva,
                    PrefiraneGodineIskstva = opis?.PrefiraneGodineIskstva
                }
            };

            return oglasOpis; 
        }
    }
}
