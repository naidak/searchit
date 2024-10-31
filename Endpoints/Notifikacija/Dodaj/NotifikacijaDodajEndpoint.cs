using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Oglas.Dodaj;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JobSearchingWebApp.Endpoints.Notifikacija.Dodaj
{
    [Authorize]
    [Tags("Notifikacija")]
    [Route("notifikacija-dodaj")]
    public class NotifikacijaDodajEndpoint : MyBaseEndpoint<NotifikacijaDodajRequest, ActionResult<NotifikacijaDodajResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;


        public NotifikacijaDodajEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<ActionResult<NotifikacijaDodajResponse>> MyAction(NotifikacijaDodajRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var notifikacija = new Database.Notifikacija()
            {
                Naziv = request.naziv,
                Vrsta = request.vrsta
            };

            dbContext.Notifikacije.Add(notifikacija);
            await dbContext.SaveChangesAsync();

            return new NotifikacijaDodajResponse { Id = notifikacija.Id };
        }
    }
}
