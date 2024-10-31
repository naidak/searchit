using Azure.Core;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Oglas.GetAll;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Oglas.Dodaj.GetObjavljen
{
    [AllowAnonymous]
    [Tags("Oglas")]
    [Route("oglas-get-by-objavljen")]
    public class OglasGetObjavljenEndpoint : MyBaseEndpoint<bool, OglasGetObjavljenResponse>
    {
        private readonly ApplicationDbContext dbContext;
        public OglasGetObjavljenEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        [HttpGet("{objavljen}")]
        public override async Task<OglasGetObjavljenResponse> MyAction(bool objavljen, CancellationToken cancellationToken)
        {
            var oglasi = dbContext.Oglasi.Include(k=> k.Kompanija).AsEnumerable().Where(x=> x.Objavljen == objavljen && x.Kompanija.IsObrisan == false).ToList();

            var lista = oglasi.Select(oglas => new OglasGetObjavljenResponseOglas
            {
                Id = oglas.Id,
                KompanijaId = oglas.KompanijaId,
                KompanijaNaziv = oglas.Kompanija?.Naziv?? "N/A",
                NazivPozicije = oglas.NazivPozicije,
                DatumObjave = oglas.DatumObjave,
                TipPosla = oglas.TipPosla,
                RokPrijave = oglas.RokPrijave,
                Iskustvo = dbContext.OglasIskustvo
                        .Where(iskustvo => iskustvo.OglasId == oglas.Id)
                        .Select(iskustvo => new OglasGetByObjavljenResponseOglasIskustvo
                        {
                            Id = iskustvo.IskustvoId,
                            Naziv = iskustvo.Iskustvo.Naziv
                        })
                        .ToList(),

                Lokacija = dbContext.OglasLokacija
                            .Where(lokacija => lokacija.OglasId == oglas.Id)
                            .Select(lokacija => new OglasGetByObjavljenResponseOglasLokacija
                            {
                                Id = lokacija.LokacijaId,
                                Naziv = lokacija.Lokacija.Naziv
                            })
                            .ToList(),
                OpisOglasa = dbContext.OpisOglas
                          .Where(opis => opis.OglasId == oglas.Id)
                          .Select(opis => new OglasGetByObjavljenResponseOpisOglasa
                          {
                              MinimumGodinaIskustva = (int)opis.MinimumGodinaIskustva,
                              PrefiraneGodineIskstva = (int)opis.PrefiraneGodineIskstva,
                              Benefiti = opis.Benefiti,
                              Vjestine = opis.Vjestine,
                              Kvalifikacija = opis.Kvalifikacija,
                              OpisPozicije = opis.OpisPozicije
                          })
                          .SingleOrDefault()!,
            }).ToList();

            OglasGetObjavljenResponse oglasGetObjavljenResponse = new OglasGetObjavljenResponse { Oglasi = lista };
            return oglasGetObjavljenResponse;
        }
    }
}
