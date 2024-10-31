using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.ViewModels;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Kandidat.Delete
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("Kandidat")]
    [Route("kandidat-delete")]
    public class KandidatDeleteEndpoint : MyBaseEndpoint<string, ActionResult<NoResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KandidatDeleteEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
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

                var kandidat = dbContext.Kandidati.FirstOrDefault(x => x.Id == id);

                if (kandidat == null)
                    return BadRequest(new { message = $"User with ID {id} doesn't exist." });

                kandidat.IsObrisan = true;

                await dbContext.SaveChangesAsync();   

                return new NoResponse() { };
            }

            else return Unauthorized();
        }
    }
}
