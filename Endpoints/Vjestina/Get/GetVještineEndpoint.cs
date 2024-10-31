using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.Endpoints.Kompanija.GetBrojZaposlenihRange;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchingWebApp.Endpoints.Vjestina.Get
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("Vjestine")]
    [Route("vjestine-get")]
    public class GetVještineEndpoint : MyBaseEndpoint<NoRequest, ActionResult<GetVještineResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public GetVještineEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<GetVještineResponse>> MyAction([FromQuery] NoRequest noRequest, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var ranges = VještineExtensions.GetAllVještine();

            return new GetVještineResponse() { lista = ranges };
        }
    }
}
