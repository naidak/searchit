using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Oglas.Update;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JobSearchingWebApp.Endpoints.Notifikacija.Update
{
    [Authorize]
    [Tags("Notifikacija")]
    [Route("notifikacija-update")]
    public class NotifikacijaUpdateEndpoint : MyBaseEndpoint<NotifikacijaUpdateRequest, ActionResult<NotifikacijaUpdateResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public NotifikacijaUpdateEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPut]
        public override async Task<ActionResult<NotifikacijaUpdateResponse>> MyAction(NotifikacijaUpdateRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");

            }

            var notifikacija = dbContext.Notifikacije.FirstOrDefault(x => x.Id == request.notifikacija_id);

            if (notifikacija == null)
            {
                return NotFound($"Unable to load notification with ID {request.notifikacija_id}.");
            }

            notifikacija.Naziv = request.naziv; 
            notifikacija.Vrsta = request.vrsta;

            await dbContext.SaveChangesAsync();

            return new NotifikacijaUpdateResponse { Id = notifikacija.Id };
        }
    }
}
