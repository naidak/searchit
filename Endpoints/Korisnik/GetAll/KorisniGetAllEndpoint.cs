using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kompanija.GetAll;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.Korisnik.GetAll
{
    //[Authorize(Roles = "Admin")]
    [Tags("Korisnik")]
    [Route("korisnici-get")]
    public class KorisniGetAllEndpoint : MyBaseEndpoint<KorisnikGetAllRequest, ActionResult<KorisnikGetAllResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KorisniGetAllEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<KorisnikGetAllResponse>> MyAction([FromQuery] KorisnikGetAllRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var korisnici = dbContext.Korisnici.Include(x => x.Uloga).AsQueryable();

            var response = korisnici.Select(korisnik => new KorisnikGetAllResponseKorisnik
            {
                IsObrisan = korisnik.IsObrisan,
                Uloga = korisnik.Uloga.Naziv
            }).ToList();

            return new KorisnikGetAllResponse { Korisnici = response };
        }
    }
}
