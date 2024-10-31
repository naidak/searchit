using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Endpoints.Oglas.Delete;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchingWebApp.Endpoints.Oglas.SoftDelete
{
    [Authorize(Roles = "Admin, Kompanija")]
    [Tags("Oglas")]
    [Route("oglas-soft-delete")]
    public class OglasSoftDeleteEndpoint:MyBaseEndpoint<OglasSoftDeleteRequest, ActionResult<OglasSoftDeleteResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public OglasSoftDeleteEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPut]
        public override async Task<ActionResult<OglasSoftDeleteResponse>> MyAction([FromBody] OglasSoftDeleteRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var oglas = dbContext.Oglasi.FirstOrDefault(x => x.Id == request.oglas_id);
        
            if (oglas == null)
            {
                return new OglasSoftDeleteResponse
                {
                    Success = false,
                    Message = "Oglas not found with ID " + request.oglas_id
                };
            }

            // Mark the record as deleted
            oglas.IsObrisan = true;
            dbContext.Oglasi.Update(oglas);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new OglasSoftDeleteResponse
            {
                Success = true,
                Message = "Oglas soft-deleted successfully"
            };
        }
    }
}
