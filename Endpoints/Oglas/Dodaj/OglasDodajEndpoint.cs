using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JobSearchingWebApp.Endpoints.Oglas.Dodaj
{
    [Authorize(Roles = "Admin, Kompanija")]
    [Tags("Oglas")]
    [Route("oglas-dodaj")]
    public class OglasDodajEndpoint : MyBaseEndpoint<OglasDodajRequest, OglasDodajResponse>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public OglasDodajEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        public override async Task<OglasDodajResponse> MyAction(OglasDodajRequest request, CancellationToken cancellationToken)
        {
            var oglas = new Database.Oglas()
            {
                KompanijaId = request.kompanija_id,
                NazivPozicije = request.naziv_pozicije,
                DatumObjave = request.datum_objave,
                Plata = request.plata,
                TipPosla = request.tip_posla,
                RokPrijave = request.rok_prijave,
                DatumModificiranja = request.datum_modificiranja,
                OpisOglas = new Database.OpisOglas()
                {
                    OpisPozicije = request.opis_pozicije,
                    MinimumGodinaIskustva = request?.minimum_godina_iskustva,
                    PrefiraneGodineIskstva = request?.preferirane_godine_iskustva,
                    Benefiti = request?.benefiti,
                    Kvalifikacija = request?.kvalifikacija,
                    Vjestine = request?.vjestine,
                },
                Objavljen = request?.objavljen
            };

            foreach (var nazivLokacije in request.lokacija)
            {
                // Check if this experience already exists
                var existingLokacija = dbContext.Lokacija.FirstOrDefault(x => x.Naziv.ToLower() == nazivLokacije.ToLower());

                // If it doesn't exist, add a new one
                if (existingLokacija == null)
                {
                    existingLokacija = new Database.Lokacija() { Naziv = nazivLokacije };
                    dbContext.Lokacija.Add(existingLokacija);
                    await dbContext.SaveChangesAsync();  // Save the new experience to avoid duplicates
                }

                // Add the experience to the oglas
                oglas.OglasLokacija.Add(new OglasLokacija() { Lokacija = existingLokacija });
            }

            foreach (var nazivIskustva in request.iskustvo)
            {
                // Check if this experience already exists
                var existingIskustvo = dbContext.Iskustvo.FirstOrDefault(x => x.Naziv.ToLower() == nazivIskustva.ToLower());

                // If it doesn't exist, add a new one
                if (existingIskustvo == null)
                {
                    existingIskustvo = new Database.Iskustvo() { Naziv = nazivIskustva };
                    dbContext.Iskustvo.Add(existingIskustvo);
                    await dbContext.SaveChangesAsync();  // Save the new experience to avoid duplicates
                }

                // Add the experience to the oglas
                oglas.OglasIskustvo.Add(new OglasIskustvo() { Iskustvo = existingIskustvo });
            }

            // Save the oglas and related entities
            dbContext.Oglasi.Add(oglas);
            await dbContext.SaveChangesAsync();

            return new OglasDodajResponse { Id = oglas.Id };
        }
    }
}
