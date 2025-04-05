using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.Poruka.GetAllChats
{
    [Route("all-chats")]
    [AllowAnonymous]
    public class PorukaGetAllChatsEndpoint : MyBaseEndpoint<PorukaGetAllChatsRequest, PorukaGetAllChatsResponse>
    {
        private readonly Data.ApplicationDbContext dbContext;
        public PorukaGetAllChatsEndpoint(Data.ApplicationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public override async Task<PorukaGetAllChatsResponse> MyAction([FromQuery]PorukaGetAllChatsRequest request, CancellationToken cancellationToken)
        {

            var porukePrimatelj = dbContext.PorukeKorisnici.Include(p => p.Poruka)
                .Include(p => p.Posiljalac)
                .Include(p => p.Korisnik)
                .Where(x => x.KorisnikId == request.primatelj_id)
                .ToList();

            var responsePoruke = porukePrimatelj.Select(message => new PorukaGetAllChatsResponsePoruka()
            {
                id = message.Id,
                posiljatelj_id = message.PosiljalacId,
                primatelj_id = message.KorisnikId,
                posiljatelj_ime = message.Posiljalac.UserName ?? "",
                primatelj_ime = message.Korisnik.UserName??"",
                is_seen = dbContext.Poruke.Where(x => x.Id == message.PorukaId).First().IsSeen,
                vrijeme_slanja = dbContext.Poruke.Where(x => x.Id == message.PorukaId).First().VrijemeSlanja,
                sadrzaj = dbContext.Poruke.Where(x=> x.Id == message.PorukaId).First().Sadrzaj
            }).OrderBy(c => c.vrijeme_slanja).ToList();

            var totalMessages = responsePoruke.Count();
            var totalUnseenMessages = responsePoruke.Count(p => !p.is_seen);
            
            return new PorukaGetAllChatsResponse()
            {
                poruke = responsePoruke,
                broj_neprocitanih = totalUnseenMessages,
                total_poruka = totalMessages
            };
        }

    }

}
