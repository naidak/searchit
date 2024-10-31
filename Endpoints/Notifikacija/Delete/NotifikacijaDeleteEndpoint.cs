using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Endpoints.Oglas.Delete;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Notifikacija.Delete
{
    [Authorize]
    [Tags("Notifikacija")]
    [Route("notifikacija-delete")]
    public class NotifikacijaDeleteEndpoint : MyBaseEndpoint<NotifikacijaDeleteRequest, ActionResult<NoResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public NotifikacijaDeleteEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpDelete]
        public override async Task<ActionResult<NoResponse>> MyAction([FromQuery]NotifikacijaDeleteRequest request, CancellationToken cancellationToken)
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

            dbContext.Remove(notifikacija);
            await dbContext.SaveChangesAsync();

            return new NoResponse() { };
        }
    }
}
