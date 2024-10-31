using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Notifikacija.GetAll
{
    [Authorize]
    [Tags("Notifikacija")]
    [Route("notifikacija-pretraga")]
    public class NotifikacijaGetAllEndpoint : MyBaseEndpoint<NotifikacijaGetAllRequest, ActionResult<NotifikacijaGetAllResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public NotifikacijaGetAllEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<NotifikacijaGetAllResponse>> MyAction([FromQuery] NotifikacijaGetAllRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");

            }
            var notifikacije = await dbContext.Notifikacije
                                              .Where(x => (request.naziv == null || x.Naziv.ToLower().StartsWith(request.naziv.ToLower()))
                                                       && (request.vrsta == null || x.Vrsta.ToLower().StartsWith(request.vrsta.ToLower())))
                                              .Select(x => new NotifikacijeGetAllResponse()
                                              {
                                                  Id = x.Id, 
                                                  Naziv = x.Naziv,
                                                  Vrsta = x.Vrsta,
                                              }).ToListAsync();

            return new NotifikacijaGetAllResponse { Notifikacije = notifikacije };
        }
    }
}
