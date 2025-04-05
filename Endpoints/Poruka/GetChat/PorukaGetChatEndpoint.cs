using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.Poruka.GetChat
{
    [Route("chat")]
    [AllowAnonymous]
    public class PorukaGetChatEndpoint : MyBaseEndpoint<PorukaGetChatRequest, PorukaGetChatResponse>
    {
        private readonly Data.ApplicationDbContext _context;
        public PorukaGetChatEndpoint(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public override async Task<PorukaGetChatResponse> MyAction( [FromQuery]PorukaGetChatRequest request, CancellationToken cancellationToken)
        {
          var porukeKorisnici = await _context.PorukeKorisnici
          .Include(p => p.Poruka)
          .Include(p => p.Posiljalac)
          .Include(k => k.Korisnik)
          .Where(x => (x.PosiljalacId == request.korisnik1_id && x.KorisnikId == request.korisnik2_id)
                   || (x.PosiljalacId == request.korisnik2_id && x.KorisnikId == request.korisnik1_id))
          .Select(message => new PorukaGetChatResponsePoruka
          {
              id = message.Id,
              posiljatelj_id = message.PosiljalacId,
              posiljatelj_ime = message.Posiljalac.UserName ?? "",
              primatelj_id = message.KorisnikId,
              primatelj_ime = message.Korisnik.UserName ?? "",
              is_seen = message.Poruka.IsSeen,
              sadrzaj = message.Poruka.Sadrzaj ?? "",
              vrijeme_slanja = message.Poruka.VrijemeSlanja
          })
          .OrderBy(c => c.vrijeme_slanja)
          .ToListAsync(cancellationToken);

            return new PorukaGetChatResponse
            {
                poruke = porukeKorisnici,
                broj_neprocitanih = porukeKorisnici.Count(p => !p.is_seen),
                total_poruka = porukeKorisnici.Count
            };
        }
    }
}
