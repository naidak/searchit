using Azure.Core;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.ViewModels;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using JobSearchingWebApp.Helper.Services;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;

namespace JobSearchingWebApp.Endpoints.Kandidat.Dodaj
{
    [AllowAnonymous]
    [Tags("Kandidat")]
    [Route("kandidat-dodaj")]
    public class KandidatDodajEndpoint : MyBaseEndpoint<KandidatDodajRequest, IActionResult>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<Database.Korisnik> userManager;

        public KandidatDodajEndpoint(ApplicationDbContext dbContext, IMapper mapper, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager; 
        }

        [HttpPost]
        public override async Task<IActionResult> MyAction([FromBody] KandidatDodajRequest request, CancellationToken cancellationToken)
        {
            var kandidat = mapper.Map<Database.Kandidat>(request);
            kandidat.PasswordSalt = HelperMethods.GenerateSalt();
            kandidat.UlogaId = 2;
            kandidat.IsObrisan = false; 

            var result = await userManager.CreateAsync(kandidat, request.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await userManager.AddToRoleAsync(kandidat, "Kandidat");

            return Ok(new { Result = "User created successfully" });
        }
    }
}
