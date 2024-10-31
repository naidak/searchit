using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Endpoints.Kandidat.Delete;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Oglas.Delete
{
    [Authorize(Roles = "Admin, Kompanija")]
    [Tags("Oglas")]
    [Route("oglas-delete")]
    public class OglasDeleteEndpoint : MyBaseEndpoint<OglasDeleteRequest, IActionResult>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public OglasDeleteEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpDelete]
        public override async Task<IActionResult> MyAction([FromQuery]OglasDeleteRequest request, CancellationToken cancellationToken)
        {

            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound(new { message = $"Unable to load user with ID {userManager.GetUserId(User)}." });
            }

            try
            {
                var oglas = dbContext.Oglasi.FirstOrDefault(x => x.Id == request.oglas_id);

                if (oglas == null)
                {
                    return NotFound(new { message = "Oglas not found with ID " + request.oglas_id });
                }

                var relatedOglasIskustva = dbContext.OglasIskustvo.Where(oi => oi.OglasId == oglas.Id).ToList();
                dbContext.OglasIskustvo.RemoveRange(relatedOglasIskustva);
                dbContext.SaveChanges();

                dbContext.Oglasi.Remove(oglas);
                await dbContext.SaveChangesAsync(cancellationToken);

                return Ok(new OglasDeleteResponse());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting oglas: {ex.Message}");
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }
    }
}
