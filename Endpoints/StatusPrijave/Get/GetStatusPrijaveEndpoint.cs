using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchingWebApp.Endpoints.StatusPrijave.Get
{
    [Authorize]
    [Tags("StatusPrijave")]
    [Route("status-prijave-get")]
    public class GetStatusPrijaveEndpoint : MyBaseEndpoint<NoRequest, ActionResult<GetStatusPrijaveResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public GetStatusPrijaveEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<GetStatusPrijaveResponse>> MyAction([FromQuery] NoRequest noRequest, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var lista = StatusPrijaveExtensions.GetAllStatusPrijave();

            return new GetStatusPrijaveResponse() { lista = lista };
        }
    }
}
