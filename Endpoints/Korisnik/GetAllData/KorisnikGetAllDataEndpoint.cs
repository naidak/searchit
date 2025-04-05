using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.Korisnik.GetAllData
{
    [Route("korisnici-get-all")]
    [Tags("Korisnik")]
    public class KorisnikGetAllDataEndpoint : MyBaseEndpoint<KorisnikGetAllDataRequest, KorisnikGetAllDataResponse>
    {
        private readonly ApplicationDbContext dbContext;

        public KorisnikGetAllDataEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public override async Task<KorisnikGetAllDataResponse> MyAction([FromQuery]KorisnikGetAllDataRequest request, CancellationToken cancellationToken)
        {
            var korisnici = await dbContext.Korisnici
                                           .Include(x => x.Uloga)
                                           .ToListAsync(cancellationToken);

            var response = korisnici.Select(korisnik => new KorisnikGetAllDataResponseKorisnik
            {
                IsObrisan = korisnik.IsObrisan,
                Uloga = korisnik.Uloga.Naziv,
                Username = korisnik.UserName
            }).ToList();

            return new KorisnikGetAllDataResponse { Korisnici = response };
        }

    }

}