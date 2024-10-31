using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace JobSearchingWebApp.Endpoints.Oglas.GetAll
{
    [AllowAnonymous]
    [Tags("Oglas")]
    [Route("oglas-get")]
    public class OglasGetAllEndpoint : MyBaseEndpoint<OglasGetAllRequest, OglasGetAllResponse>
    {
        private readonly ApplicationDbContext dbContext;

        public OglasGetAllEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public override async Task<OglasGetAllResponse> MyAction([FromQuery] OglasGetAllRequest request, CancellationToken cancellationToken)
        {
            var oglasi = dbContext.Oglasi.Include(x => x.Kompanija)
                                         .Where(x => x.IsObrisan == false 
                                                  && x.Kompanija.IsObrisan == false)
                                         .AsQueryable();

            var lokacije = dbContext.OglasLokacija.Include(lokacija => lokacija.Lokacija).AsQueryable();

            var iskustva = dbContext.OglasIskustvo.Include(iskustvo => iskustvo.Iskustvo).AsQueryable();

            var spaseni = dbContext.KandidatSpaseniOglasi.Include(spaseni => spaseni.Oglas)
                                                         .Include(spaseni => spaseni.Kandidat)
                                                         .Where(x => x.Oglas.IsObrisan == false 
                                                                  && x.Kandidat.IsObrisan == false)
                                                         .AsQueryable();

            if (!string.IsNullOrEmpty(request.Naziv))
            {
                oglasi = oglasi.Where(oglas => oglas.NazivPozicije.ToLower().Contains(request.Naziv.ToLower()) 
                                            || oglas.Kompanija.Naziv.ToLower().Contains(request.Naziv.ToLower())); 
            }

            if (request?.Lokacija?.Count > 0)
            { 
                oglasi = oglasi
                        .Where(oglas => lokacije
                                    .Where(l => l.OglasId == oglas.Id)
                                    .Any(lokacija => request.Lokacija.Contains(lokacija.Lokacija.Naziv)) == true);
            }

            if (request?.Iskustvo?.Count() > 0)
            {
                oglasi = oglasi
                        .Where(oglas => iskustva
                                    .Where(l => l.OglasId == oglas.Id)
                                    .Any(iskustvo => request.Iskustvo.Contains(iskustvo.Iskustvo.Naziv)) == true);
            }

            if (request?.TipPosla?.Count() > 0)
            {
                oglasi = oglasi
                        .Where(oglas => request.TipPosla.Contains(oglas.TipPosla) == true);
            }

            if (request?.MinimumGodinaIskustva != null)
            {
                
                oglasi = oglasi.Where(oglas => oglas.OpisOglas.MinimumGodinaIskustva <= request.MinimumGodinaIskustva);
            }

            if (request?.KompanijaId != null)
            {

                oglasi = oglasi.Where(oglas => oglas.KompanijaId == request.KompanijaId);
            }

            if (request?.Otvoren != null)
            {
                if(request?.Otvoren == true)
                    oglasi = oglasi.Where(oglas => oglas.RokPrijave > DateTime.Now);

                else
                    oglasi = oglasi.Where(oglas => oglas.RokPrijave < DateTime.Now);
            }

            if (request?.Spasen != null)
            {
                oglasi = oglasi.Where(oglas => oglas.KandidatSpaseniOglasi.Any(spaseni => spaseni.KandidatId == request.KandidatId && spaseni.Spasen == true));
            }

            if(request?.Objavljen!=null)
            {
                oglasi= oglasi.Where(oglas => oglas.Objavljen ==  request.Objavljen);   
            }

            if (request?.Objavljen.HasValue ?? false)
            {
                bool objavljenValue = request.Objavljen.Value;
                oglasi = oglasi.Where(oglas => oglas.Objavljen == objavljenValue);
            }


            var lista = oglasi.Select(oglas => new OglasGetAllResponseOglas
            {
                Id = oglas.Id,
                KompanijaNaziv = oglas.Kompanija.Naziv,
                Logo = oglas.Kompanija!.Logo != null ? Convert.ToBase64String(oglas.Kompanija!.Logo) : null,
                NazivPozicije = oglas.NazivPozicije,
                DatumObjave = oglas.DatumObjave,
                TipPosla = oglas.TipPosla,
                RokPrijave = oglas.RokPrijave,
                Objavljen = oglas.Objavljen,    
                IsObrisan = oglas.IsObrisan, 
                Spasen = oglas.KandidatSpaseniOglasi.Any(x => x.KandidatId == request.KandidatId && x.OglasId == oglas.Id && x.Spasen),
                Iskustvo = dbContext.OglasIskustvo
                                    .Where(iskustvo => iskustvo.OglasId == oglas.Id)
                                    .Select(iskustvo => new OglasGetAllResponseOglasIskustvo
                                    {
                                        Id = iskustvo.IskustvoId,
                                        Naziv = iskustvo.Iskustvo.Naziv
                                    })
                                    .ToList(),

                Lokacija = dbContext.OglasLokacija
                                    .Where(lokacija => lokacija.OglasId == oglas.Id)
                                    .Select(lokacija => new OglasGetAllResponseOglasLokacija
                                    {
                                        Id = lokacija.LokacijaId,
                                        Naziv = lokacija.Lokacija.Naziv
                                    })
                                    .ToList(),
                OpisOglasa = dbContext.OpisOglas
                                      .Where(opis => opis.OglasId == oglas.Id)
                                      .Select(opis => new OglasGetAllResponseOpisOglas
                                      {
                                          Id = opis.Id,
                                          MinimumGodinaIskustva = opis.MinimumGodinaIskustva ?? 1,
                                          PrefiraneGodineIskstva = opis.PrefiraneGodineIskstva ?? 1
                                      })
                                      .SingleOrDefault()!,
            }).ToList();
  
            if (request?.SortParametri != null && request?.SortParametri.Count() > 0)
            {
                foreach (var parametar in request.SortParametri)
                {
                    if (!string.IsNullOrEmpty(parametar.Naziv))
                    {
                        if (parametar.Redoslijed == "asc")
                            lista = HelperMethods.SortByProperty(lista, parametar.Naziv, true).ToList();

                        else if (parametar.Redoslijed == "desc")
                            lista = HelperMethods.SortByProperty(lista, parametar.Naziv, false).ToList();
                    }
                }
            }

            return new OglasGetAllResponse { Oglasi = lista };
        }
    }
}


