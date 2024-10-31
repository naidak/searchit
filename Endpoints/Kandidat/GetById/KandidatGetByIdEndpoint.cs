using Azure.Core;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Kandidat.GetById
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("Kandidat")]
    [Route("kandidat/get-by-id")]
    public class KandidatGetByIdEndpoint : MyBaseEndpoint<string, ActionResult<KandidatGetByIdResponse>>
    {
        private readonly UserManager<Database.Korisnik> userManager;
        private readonly IMapper mapper;

        public KandidatGetByIdEndpoint(UserManager<Database.Korisnik> userManager, IMapper mapper)
        {
            this.userManager = userManager; 
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<KandidatGetByIdResponse>> MyAction(string id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null || user.IsObrisan == true)
            {
                return BadRequest(new { message = $"User with ID {id} doesn't exist." });
            }

            if (user.UlogaId != 2)
            {
                return BadRequest(new { message = $"User with ID {id} is not candidate." });
            }

            var response = mapper.Map<KandidatGetByIdResponse>(user);

            return response; 
        }
    }
}
