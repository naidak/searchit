using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.CV.Dodaj;
using JobSearchingWebApp.Endpoints.Kompanija.Dodaj;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.Kompanija.GetBrojZaposlenihRange
{
    [AllowAnonymous]
    [Tags("Kompanija")]
    [Route("broj-zaposlenih")]
    public class GetBrojZaposlenihEndpoint : MyBaseEndpoint<NoRequest, GetBrojZaposlenihResponse>
    {
        private readonly ApplicationDbContext dbContext;

        public GetBrojZaposlenihEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public override async Task<GetBrojZaposlenihResponse> MyAction([FromQuery]NoRequest noRequest, CancellationToken cancellationToken)
        {
            var ranges = BrojZaposlenihExtensions.GetAllEmployeeCountRanges();
            return new GetBrojZaposlenihResponse() { lista = ranges }; 
        }
    }
}
