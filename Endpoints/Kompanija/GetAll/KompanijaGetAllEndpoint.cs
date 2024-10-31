using Azure;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Oglas.GetAll;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace JobSearchingWebApp.Endpoints.Kompanija.GetAll
{
    [AllowAnonymous]
    [Tags("Kompanija")]
    [Route("kompanija-get")]
    public class KompanijaGetAllEndpoint : MyBaseEndpoint<KompanijaGetAllRequest, KompanijaGetAllResponse>
    {
        private readonly ApplicationDbContext dbContext;

        public KompanijaGetAllEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public override async Task<KompanijaGetAllResponse> MyAction([FromQuery] KompanijaGetAllRequest request, CancellationToken cancellationToken)
        {
            var kompanije = dbContext.Kompanije.Where(kompanija => kompanija.IsObrisan == false).AsQueryable();

            var oglasi = dbContext.Oglasi.Include(kompanija => kompanija.Kompanija)
                                         .Where(oglas => oglas.IsObrisan == false).AsQueryable();

            var spaseni = dbContext.KandidatSpaseneKompanije.Include(spaseni => spaseni.Kompanija)
                                                            .Include(spaseni => spaseni.Kandidat)
                                                            .Where(spaseni => spaseni.Kompanija.IsObrisan == false
                                                                           && spaseni.Kandidat.IsObrisan == false)
                                                            .AsQueryable();

            if (!string.IsNullOrEmpty(request.Naziv))
            {
                kompanije = kompanije.Where(kompanija => kompanija.Naziv.ToLower().Contains(request.Naziv.ToLower()));
            }

            if (request?.Lokacija?.Count > 0)
            {
                kompanije = kompanije.Where(kompanija => request.Lokacija.Contains(kompanija.Lokacija.Naziv));
            }

            if (request?.BrojZaposlenih?.Count > 0)
            {
                kompanije = kompanije.Where(kompanija => request.BrojZaposlenih.Contains(kompanija.BrojZaposlenih));
            }

            if (request?.Spasen != null)
            {
                kompanije = kompanije.Where(kompanija => kompanija.KandidatSpaseneKompanije.Any(spaseni => spaseni.KandidatId == request.KandidatId && spaseni.Spasen == true));
            }

            if (request?.ImaOtvorenePozicije != null)
            {
                if(request.ImaOtvorenePozicije == "Positions available")
                {
                    kompanije = kompanije.Where(kompanija => oglasi
                                   .Any(oglas => oglas.KompanijaId == kompanija.Id && oglas.RokPrijave > DateTime.Now));
                }
                
                else if (request.ImaOtvorenePozicije == "No open positions")
                {
                    kompanije = kompanije.Where(kompanija => !(oglasi
                                   .Any(oglas => oglas.KompanijaId == kompanija.Id && oglas.RokPrijave > DateTime.Now)));
                }
            }

            var lista = kompanije.Select(kompanija => new KompanijaGetAllResponseKompanija
            {
                Id = kompanija.Id,
                Naziv = kompanija.Naziv,
                Lokacija = kompanija.Lokacija.Naziv,
                GodinaOsnivanja = kompanija.GodinaOsnivanja,
                Logo = kompanija!.Logo != null ? Convert.ToBase64String(kompanija!.Logo) : null,
                BrojZaposlenih = kompanija.BrojZaposlenih,
                KratkiOpis = kompanija.KratkiOpis,
                Opis = kompanija.Opis,
                Website = kompanija.Website ?? null,
                LinkedIn = kompanija.LinkedIn ?? null,
                Twitter = kompanija.Twitter ?? null, 
                Spasen = spaseni.Any(x => x.KandidatId == request.KandidatId && x.KompanijaId == kompanija.Id && x.Spasen),
                BrojOtvorenihPozicija = kompanija.Oglasi.Count(x => x.KompanijaId == kompanija.Id && x.RokPrijave > DateTime.Now),
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

            return new KompanijaGetAllResponse { Kompanije =  lista };  
        }
    }
}
