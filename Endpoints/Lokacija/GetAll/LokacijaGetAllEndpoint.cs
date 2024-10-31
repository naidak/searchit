using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchingWebApp.Endpoints.Lokacija.GetAll
{
    [AllowAnonymous]
    [Tags("Lokacija")]
    [Route("lokacija-get")]
    public class LokacijaGetAllEndpoint : MyBaseEndpoint<LokacijaGetAllRequest, LokacijaGetAllResponse>
    {
        private readonly ApplicationDbContext dbContext;

        public LokacijaGetAllEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public override async Task<LokacijaGetAllResponse> MyAction([FromQuery] LokacijaGetAllRequest request, CancellationToken cancellationToken)
        {
            var lokacije = dbContext.Lokacija.AsQueryable();

            var response = lokacije.Select(lokacija => new LokacijaGetAllResponseLokacija
            {
                Id = lokacija.Id,
                Naziv = lokacija.Naziv,
            }).ToList();

            return new LokacijaGetAllResponse { Lokacije = response };
        }
    }
}
