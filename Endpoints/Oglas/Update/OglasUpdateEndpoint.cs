using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Kandidat.Update;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JobSearchingWebApp.Endpoints.Oglas.Update
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("Oglas")]
    [Route("oglas-update")]
    public class OglasUpdateEndpoint : MyBaseEndpoint<OglasUpdateRequest, ActionResult<OglasUpdateResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public OglasUpdateEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<ActionResult<OglasUpdateResponse>> MyAction(OglasUpdateRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var oglas = dbContext.Oglasi
                .Include(o => o.OpisOglas)  // Explicitly include OpisOglas
                .Include(o => o.OglasLokacija)
                .Include(o => o.OglasIskustvo)
                .FirstOrDefault(x => x.Id == request.oglas_id);

            if (oglas == null)
            {
                throw new Exception("Nije pronađen oglas sa ID " + request.oglas_id);
            }

            // Update the fields of the Oglas entity
            oglas.NazivPozicije = request?.naziv_pozicije;
            oglas.RokPrijave = request.rok_prijave ?? oglas.RokPrijave;
            oglas.DatumModificiranja = DateTime.Now;

            // Update the existing OpisOglas entity
            if (oglas.OpisOglas != null)
            {
                oglas.OpisOglas.OpisPozicije = request.opis_oglasa.opis_pozicije ?? oglas.OpisOglas.OpisPozicije;
                oglas.OpisOglas.Benefiti = request?.opis_oglasa.benefiti ?? oglas.OpisOglas.Benefiti;
                oglas.OpisOglas.Kvalifikacija = request?.opis_oglasa.kvalifikacije ?? oglas.OpisOglas.Kvalifikacija;
                oglas.OpisOglas.Vjestine = request?.opis_oglasa.vjestine ?? oglas.OpisOglas.Vjestine;
                oglas.OpisOglas.PrefiraneGodineIskstva = request.opis_oglasa.preferirane_godine_iskustva ?? oglas.OpisOglas.PrefiraneGodineIskstva;
                oglas.OpisOglas.MinimumGodinaIskustva = request.opis_oglasa.minimum_godina_iskustva ?? oglas.OpisOglas.MinimumGodinaIskustva;
            }

            foreach (var lokacijaRequest in request.lokacija)
            {
                // Check if the Lokacija already exists
                var existingLokacija = await dbContext.Lokacija
                    .FirstOrDefaultAsync(l => l.Id == lokacijaRequest.id);

                if (existingLokacija == null)
                {
                    // Handle the case where Lokacija does not exist
                    existingLokacija = new Database.Lokacija
                    {
                        Id = lokacijaRequest.id,
                        Naziv = lokacijaRequest.naziv
                    };
                    dbContext.Lokacija.Add(existingLokacija);
                    await dbContext.SaveChangesAsync(); // Save the new Lokacija to get the ID
                }

                var newOglasLokacija = new OglasLokacija
                {
                    OglasId = oglas.Id,
                    LokacijaId = existingLokacija.Id // Use the existing or newly created Lokacija's ID
                };

                oglas.OglasLokacija.Add(newOglasLokacija);
            }

            oglas.OglasIskustvo.Clear();
            foreach(var iskustvoRequest in request.iskustvo)
            {
                var existingIskustvo = dbContext.Iskustvo
                    .FirstOrDefault(i => i.Id == iskustvoRequest.id);

                if(existingIskustvo == null)
                {
                    existingIskustvo = new Database.Iskustvo
                    {
                        Id = iskustvoRequest.id,
                        Naziv = iskustvoRequest.naziv
                    };
                    dbContext.Iskustvo.Add(existingIskustvo);
                    await dbContext.SaveChangesAsync();
                }
                var newOglasIskustvo = new OglasIskustvo
                {
                    IskustvoId = iskustvoRequest.id,
                    OglasId = existingIskustvo.Id,
                };

                oglas.OglasIskustvo.Add(newOglasIskustvo);
            }

            await dbContext.SaveChangesAsync();

            return new OglasUpdateResponse { Id = oglas.Id };
        }

    }
}
