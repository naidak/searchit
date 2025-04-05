using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Endpoints.Poruka.GetByKorisnikId;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.Poruka.Send
{
    [Tags("Poruka")]
    [AllowAnonymous]
    [Route("poruka-send")]
    public class PorukaSendEndpoint : MyBaseEndpoint<PorukaSendRequest, PorukaSendResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PorukaSendEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<PorukaSendResponse> MyAction([FromBody]PorukaSendRequest request, CancellationToken cancellationToken)
        {
            if (request == null || String.IsNullOrWhiteSpace(request.sadrzaj))
                return new PorukaSendResponse();

            var posiljalac = _applicationDbContext.Korisnici.Where(x => x.Id == request.posiljatelj_id).FirstOrDefault();
            var korisnik = _applicationDbContext.Korisnici.Where(x => x.Id == request.korisnik_id).FirstOrDefault();

            if (posiljalac == null || korisnik == null)
                return new PorukaSendResponse();

            var poruka = new Database.Poruka()
            {
                Sadrzaj = request.sadrzaj,
                IsSeen = false,
                VrijemeSlanja = DateTime.Now
            };

            _applicationDbContext.Add(poruka);

            var porukaKorisnik = new PorukaKorisnik()
            {
                KorisnikId = request.korisnik_id,
                PosiljalacId = request.posiljatelj_id,
                isPrimljena = false,
                Poruka = poruka
            };

            _applicationDbContext.Add(porukaKorisnik);
            await _applicationDbContext.SaveChangesAsync();

            return new PorukaSendResponse() { Id = porukaKorisnik.Id };
        }
    }
}
