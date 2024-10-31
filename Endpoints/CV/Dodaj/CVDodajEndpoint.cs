using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Oglas.Dodaj;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.CV.Dodaj
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("CV")]
    [Route("cv-dodaj")]
    public class CVDodajEndpoint : MyBaseEndpoint<CVDodajRequest, ActionResult<CVDodajResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public CVDodajEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<ActionResult<CVDodajResponse>> MyAction([FromBody]CVDodajRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);


            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if (request.KandidatId == userId || user.UlogaId == 1)
            {

                // Kreiranje CV-a
                var cv = new Database.CV
                {
                    KandidatId = request.KandidatId,
                    Naziv = request.Naziv,
                    Objavljen = request.Objavljen,
                    Ime = request.Ime,
                    Prezime = request.Prezime,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Drzava = request.Drzava,
                    Grad = request.Grad,
                    ProfesionalniSazetak = request.ProfesionalniSazetak,
                    Vjestine = request.Vjestine,
                    TehnickeVjestine = request.TehnickeVjestine,
                    Kursevi = request.Kursevi,
                    DatumModificiranja = DateTime.Now,
                };

                dbContext.CV.Add(cv);
                await dbContext.SaveChangesAsync();  // Generisanje CVId

                // Dodavanje edukacija

                if (request.Edukacija?.Count > 0)
                {
                    var edukacijaIds = new List<int>();

                    foreach (var edukacijaRequest in request.Edukacija)
                    {
                        var edukacija = new Edukacija
                        {
                            NazivSkole = edukacijaRequest.NazivSkole,
                            DatumPocetka = edukacijaRequest.DatumPocetka,
                            DatumZavrsetka = edukacijaRequest.DatumZavrsetka,
                            Grad = edukacijaRequest.Grad,
                            Opis = edukacijaRequest.Opis
                        };

                        dbContext.Edukacija.Add(edukacija);
                        await dbContext.SaveChangesAsync();  // Generisanje EdukacijaId

                        edukacijaIds.Add(edukacija.Id);
                    }

                    // Dodavanje CVEdukacija
                    foreach (var edukacijaId in edukacijaIds)
                    {
                        var cvEdukacija = new CVEdukacija
                        {
                            CVId = cv.Id,
                            EdukacijaId = edukacijaId
                        };

                        dbContext.CVEdukacija.Add(cvEdukacija);
                    }

                    await dbContext.SaveChangesAsync();
                }


                // Dodavanje zaposlenja

                if (request.Zaposlenje?.Count > 0)
                {
                    var zaposlenjeIds = new List<int>();

                    foreach (var zaposlenjeRequest in request.Zaposlenje)
                    {
                        var zaposlenje = new Zaposlenje
                        {
                            NazivKompanije = zaposlenjeRequest.NazivKompanije,
                            NazivPozicije = zaposlenjeRequest.NazivPozicije,
                            DatumPocetka = zaposlenjeRequest.DatumPocetka,
                            DatumZavrsetka = zaposlenjeRequest.DatumZavrsetka,
                            Opis = zaposlenjeRequest.Opis
                        };

                        dbContext.Zaposlenje.Add(zaposlenje);
                        await dbContext.SaveChangesAsync();  // Generisanje ZaposlenjeId

                        zaposlenjeIds.Add(zaposlenje.Id);
                    }

                    // Dodavanje CVZaposlenje
                    foreach (var zaposlenjeId in zaposlenjeIds)
                    {
                        var cvZaposlenje = new CVZaposlenje
                        {
                            CVId = cv.Id,
                            ZaposlenjeId = zaposlenjeId
                        };

                        dbContext.CVZaposlenje.Add(cvZaposlenje);
                    }

                }


                // Dodavanje URL

                if (request.URL?.Count > 0)
                {
                    var urlIds = new List<int>();

                    foreach (var urlRequest in request.URL)
                    {
                        var url = new URL
                        {
                            Naziv = urlRequest.Naziv,
                            Putanja = urlRequest.Putanja
                        };

                        dbContext.URL.Add(url);
                        await dbContext.SaveChangesAsync();  // Generisanje URLId

                        urlIds.Add(url.Id);
                    }

                    // Dodavanje CVURL
                    foreach (var urlId in urlIds)
                    {
                        var cvURL = new CVURL
                        {
                            CVId = cv.Id,
                            URLId = urlId
                        };

                        dbContext.CVURL.Add(cvURL);
                    }
                }



                // Save all changes
                await dbContext.SaveChangesAsync();

                return Ok(cv.Id);
            }

            else return Unauthorized();
        }
    }
}
