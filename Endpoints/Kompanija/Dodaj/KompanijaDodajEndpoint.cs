using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kandidat.Dodaj;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.ViewModels;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Mailjet.Client.Resources;
using Microsoft.EntityFrameworkCore;


namespace JobSearchingWebApp.Endpoints.Kompanija.Dodaj
{
    [AllowAnonymous]
    [Tags("Kompanija")]
    [Route("kompanija-dodaj")]
    public class KompanijaDodajEndpoint : MyBaseEndpoint<KompanijaDodajRequest, IActionResult>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<Database.Korisnik> userManager;

        public KompanijaDodajEndpoint(ApplicationDbContext dbContext, IMapper mapper, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<IActionResult> MyAction(KompanijaDodajRequest request, CancellationToken cancellationToken)
        { 
            var kompanija = mapper.Map<Database.Kompanija>(request);
            kompanija.PasswordSalt = HelperMethods.GenerateSalt();
            kompanija.UlogaId = 3;
            kompanija.IsObrisan = false;

            var lokacija = dbContext.Lokacija.Where(x => x.Naziv == request.Lokacija).FirstOrDefault();

            if (lokacija != null)
            {
                kompanija.Lokacija = lokacija;
            }

            else
            {
                var novaLokacija = new Database.Lokacija()
                {
                    Naziv = request.Lokacija
                };

                await dbContext.Lokacija.AddAsync(novaLokacija);
                await dbContext.SaveChangesAsync();

                var nova = await dbContext.Lokacija.Where(x => x.Naziv == request.Lokacija).FirstOrDefaultAsync();

                if (nova != null)
                {
                    kompanija.Lokacija = nova;
                }
            }


            var result = await userManager.CreateAsync(kompanija, request.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await userManager.AddToRoleAsync(kompanija, "Kompanija");

            return Ok(new { Result = "User created successfully" });
        }
    }
}
