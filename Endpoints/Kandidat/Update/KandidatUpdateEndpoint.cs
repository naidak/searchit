using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kandidat.Delete;
using JobSearchingWebApp.Endpoints.Kandidat.GetById;
using JobSearchingWebApp.Helper;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchingWebApp.Endpoints.Kandidat.Update
{
   // [Authorize(Roles = "Kandidat")]
    [Tags("Kandidat")]
    [Route("kandidat-update")]
    public class KandidatUpdateEndpoint : MyBaseEndpoint<KandidatUpdateRequest, ActionResult<KandidatUpdateResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;
        private readonly IMapper mapper;

        public KandidatUpdateEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPut]
        public override async Task<ActionResult<KandidatUpdateResponse>> MyAction(KandidatUpdateRequest request, CancellationToken cancellationToken)
        {
                var kandidat = await dbContext.Kandidati.FindAsync(request.Id);

                if (kandidat == null)
                {
                    return NotFound("Unable to load user.");
                }

                kandidat.MjestoPrebivalista = request.MjestoPrebivalista ?? kandidat.MjestoPrebivalista;
                kandidat.Zvanje = request.Zvanje ?? kandidat.Zvanje;
                kandidat.Ime = request.Ime ?? kandidat.Ime;
                kandidat.Prezime = request.Prezime ?? kandidat.Prezime;
                kandidat.UserName = request.Username ?? kandidat.UserName;

                if (!String.IsNullOrEmpty(request.PhoneNumber))
                {
                    kandidat.PhoneNumber = request.PhoneNumber;
                    kandidat.PhoneNumberConfirmed = false;
                }

                await dbContext.SaveChangesAsync();

                return new KandidatUpdateResponse { id = kandidat.Id };
        
           
        }
    }
}
