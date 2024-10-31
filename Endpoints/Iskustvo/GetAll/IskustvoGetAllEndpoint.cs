using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Lokacija.GetAll;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchingWebApp.Endpoints.Iskustvo.GetAll
{
    [AllowAnonymous]
    [Tags("Iskustvo")]
    [Route("iskustvo-get")]
    public class IskustvoGetAllEndpoint : MyBaseEndpoint <IskustvoGetAllRequest, IskustvoGetAllResponse>
    {
        private readonly ApplicationDbContext dbContext;

        public IskustvoGetAllEndpoint(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public override async Task<IskustvoGetAllResponse> MyAction([FromQuery] IskustvoGetAllRequest request, CancellationToken cancellationToken)
        {
            var iskustva = dbContext.Iskustvo.AsQueryable();

            var response = iskustva.Select(iskustvo => new IskustvoGetAllResponseIskustvo
            {
                Id = iskustvo.Id,
                Naziv = iskustvo.Naziv,
            }).ToList();

            return new IskustvoGetAllResponse { Iskustva = response };
        }
    }
   
}
