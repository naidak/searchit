using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobSearchingWebApp.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JobSearchingWebApp.Migrations;

namespace JobSearchingWebApp.Endpoints.Poruka.GetByKorisnikId
{
    [AllowAnonymous]
    [Route("poruka-get")]
    [Tags("Poruka")]
    public class PorukaGetEndpoint : MyBaseEndpoint<string, PorukaGetResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PorukaGetEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("{id}")]
        public override async Task<PorukaGetResponse> MyAction(string id, CancellationToken cancellationToken)
        {
            var messagesDb = await _applicationDbContext.PorukeKorisnici
                .Where(x=> x.KorisnikId == id)
                .ToListAsync();

            var messages = messagesDb.Select(message => new PorukaGetResponsePoruka()
            {
                id = message.Id,
                korisnik_id = message.KorisnikId,
                is_primljena = message.isPrimljena,
                poruka_id = message.PorukaId,
                ime_posiljatelja = _applicationDbContext.PorukeKorisnici
                .Where(pk => pk.PorukaId == message.PorukaId)
                .Include(k => k.Korisnik)
                .Select(pk => pk.Posiljalac.UserName)
                .FirstOrDefault() ?? "NoName",
                is_seen = _applicationDbContext.PorukeKorisnici
                 .Where(pk => pk.PorukaId == message.PorukaId)
                 .Include(p => p.Poruka)
                 .Select(pk => pk.Poruka.IsSeen)
                 .FirstOrDefault(),
                sadrzaj = _applicationDbContext.PorukeKorisnici
                 .Where(pk => pk.PorukaId == message.PorukaId)
                 .Include(p => p.Poruka)
                 .Select(p => p.Poruka.Sadrzaj)
                 .FirstOrDefault() ?? "",
                vrijeme_slanja = _applicationDbContext.PorukeKorisnici
                 .Where(pk => pk.PorukaId == message.PorukaId)
                 .Include(p => p.Poruka)
                 .Select(p => p.Poruka.VrijemeSlanja)
                 .FirstOrDefault(),
                posiljatelj_id = _applicationDbContext.PorukeKorisnici
                 .Where(pk => pk.PorukaId == message.PorukaId)
                 .Include(p => p.Korisnik)
                 .Select(p => p.Posiljalac.Id)
                 .FirstOrDefault() ?? ""
            }).ToList();
            
            var response = new PorukaGetResponse()
            {
                Poruke = messages
            };

            return response;
        }
    }
}
