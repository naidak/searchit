using Azure.Core;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.CV.Delete;
using JobSearchingWebApp.Endpoints.Kandidat.Delete;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.EntityFrameworkCore;
using JobSearchingWebApp.ViewModels;

namespace JobSearchingWebApp.Endpoints.KandidatOglas.Delete
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("Kandidat-Oglas")]
    [Route("kandidat-oglas-delete")]
    public class KandidatOglasDeleteEndpoint : MyBaseEndpoint<int, ActionResult<NoResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public KandidatOglasDeleteEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<NoResponse>> MyAction(int id, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var kandidatOglas = dbContext.KandidatiOglasi.Include(x => x.Kandidat).FirstOrDefault(x => x.Id == id && x.Kandidat.IsObrisan == false);

            if (kandidatOglas == null)
            {
                return NotFound(new { message = "Application doesn't exist."});
            }

            if (kandidatOglas.KandidatId == userId || user.UlogaId == 1)
            {
                dbContext.Remove(kandidatOglas);
                await dbContext.SaveChangesAsync();

                return new NoResponse() { };
            }

            else return Unauthorized();
        }
    }
}
