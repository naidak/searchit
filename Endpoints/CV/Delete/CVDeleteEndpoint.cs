using Azure.Core;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kompanija.Delete;
using JobSearchingWebApp.Endpoints.Oglas.Delete;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using JobSearchingWebApp.ViewModels;

namespace JobSearchingWebApp.Endpoints.CV.Delete
{
    [Authorize(Roles = "Admin, Kompanija")]
    [Tags("CV")]
    [Route("cv-delete")]
    public class CVDeleteEndpoint : MyBaseEndpoint<int, ActionResult<NoResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public CVDeleteEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<NoResponse>> MyAction(int id, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);

            if (user.UlogaId == 2 || user.UlogaId == 1)
            {
                var cv = dbContext.CV.FirstOrDefault(x => x.Id == id);

                if (cv == null)
                    return BadRequest();

                else
                {

                    var kandidatiOglasi = dbContext.KandidatiOglasi.Where(x => x.CVId == id).ToList();
                    dbContext.KandidatiOglasi.RemoveRange(kandidatiOglasi);
                    await dbContext.SaveChangesAsync();

                    var cvEdukacija = dbContext.CVEdukacija.Where(x => x.CVId == id).ToList();

                    dbContext.CVEdukacija.RemoveRange(cvEdukacija);
                    await dbContext.SaveChangesAsync();

                    var cvZaposlenje = dbContext.CVZaposlenje.Where(x => x.CVId == id).ToList();

                    dbContext.CVZaposlenje.RemoveRange(cvZaposlenje);
                    await dbContext.SaveChangesAsync();

                    var cvUrl = dbContext.CVURL.Where(x => x.CVId == id).ToList();

                    dbContext.CVURL.RemoveRange(cvUrl);
                    await dbContext.SaveChangesAsync();


                    dbContext.Remove(cv);
                    await dbContext.SaveChangesAsync();

                    return new NoResponse() { };

                }
            }

            else 
                return Unauthorized();
        }
    }
}
