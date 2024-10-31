using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchingWebApp.Endpoints.TehničkeVještine.Get
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("TehnickeVjestine")]
    [Route("tehnicke-vjestine-get")]
    public class GetTehničkeVještineEndpoint : MyBaseEndpoint<NoRequest, ActionResult<GetTehničkeVještineResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public GetTehničkeVještineEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<GetTehničkeVještineResponse>> MyAction([FromQuery] NoRequest noRequest, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var ranges = TehničkeVještineExtensions.GetAllTehničkeVještine();

            return new GetTehničkeVještineResponse() { lista = ranges };
        }
    }
}
