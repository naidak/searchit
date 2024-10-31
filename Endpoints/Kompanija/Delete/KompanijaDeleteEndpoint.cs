using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kandidat.Delete;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Kompanija.Delete
{
    [Authorize(Roles = "Admin, Kompanija")]
    [Tags("Kompanija")]
    [Route("kompanija-delete")]
    public class KompanijaDeleteEndpoint : MyBaseEndpoint<string, ActionResult<NoResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KompanijaDeleteEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPatch]
        public override async Task<ActionResult<NoResponse>> MyAction([FromBody]string id, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return BadRequest(new { message = $"User with ID {id} doesn't exist." });
            }

            if (id == userId || user.UlogaId == 1)
            {

                var kompanija = dbContext.Kompanije.FirstOrDefault(x => x.Id == id);

                if (kompanija == null)
                    return BadRequest(new { message = $"User with ID {id} doesn't exist." });

                kompanija.IsObrisan = true; 

                await dbContext.SaveChangesAsync();

                return new NoResponse() { };
            }

            else return Unauthorized();
        }
    }
}
