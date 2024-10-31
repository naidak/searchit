using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.CV.Update;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Mailjet.Client.Resources;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Endpoints.CV.UpdateStatus
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("CV")]
    [Route("cv-update-status")]
    public class CVUpdateStatusEndpoint : MyBaseEndpoint<CVUpdateStatusRequest, ActionResult<CVUpdateStatusResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;
        private readonly IMapper mapper;

        public CVUpdateStatusEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPatch]
        public override async Task<ActionResult<CVUpdateStatusResponse>> MyAction(CVUpdateStatusRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if (request.KandidatId == userId || user.UlogaId == 1)
            {
                var cv = dbContext.CV.Include(cv => cv.Edukacije).ThenInclude(cv => cv.Edukacija)
                                     .Include(cv => cv.Zaposlenja).ThenInclude(cv => cv.Zaposlenje)
                                     .Include(cv => cv.URLovi).ThenInclude(cv => cv.URL)
                                     .FirstOrDefault(cv => cv.Id == request.Id);

                if (cv == null)
                {
                    return NotFound();
                }

                cv.Objavljen = request.Objavljen; 
                cv.DatumModificiranja = DateTime.Now;
                
                await dbContext.SaveChangesAsync();

                return new CVUpdateStatusResponse { Id = cv.Id };
            }

            else return Unauthorized();
        }
    }
}
