using JobSearchingWebApp.Data;
using JobSearchingWebApp.Endpoints.Oglas.Update;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Database;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Endpoints.CV.Update
{
    [Authorize(Roles = "Admin, Kandidat")]
    [Tags("CV")]
    [Route("cv-update")]
    public class CVUpdateEndpoint : MyBaseEndpoint<CVUpdateRequest, ActionResult<CVUpdateResponse>>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;
        private readonly IMapper mapper;

        public CVUpdateEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPut]
        public override async Task<ActionResult<CVUpdateResponse>> MyAction(CVUpdateRequest request, CancellationToken cancellationToken)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if (request.KandidatId == userId || user?.UlogaId == 1)
            {
                var cv = dbContext.CV.Include(cv => cv.Edukacije).ThenInclude(cv => cv.Edukacija)
                                     .Include(cv => cv.Zaposlenja).ThenInclude(cv => cv.Zaposlenje)
                                     .Include(cv => cv.URLovi).ThenInclude(cv => cv.URL)
                                     .FirstOrDefault(cv => cv.Id == request.Id);

                if (cv == null)
                {
                    return NotFound();
                }

                if (request.Objavljen != null)
                {
                    cv.Objavljen = (bool)request.Objavljen;
                }

                if (!String.IsNullOrEmpty(request.Naziv))
                {
                    cv.Naziv = request.Naziv;
                }

                if (!String.IsNullOrEmpty(request.Ime))
                {
                    cv.Ime = request.Ime;
                }

                if (!String.IsNullOrEmpty(request.Prezime))
                {
                    cv.Prezime = request.Prezime;
                }

                if (!String.IsNullOrEmpty(request.Email))
                {
                    cv.Email = request.Email;
                }

                if (!String.IsNullOrEmpty(request.Drzava))
                {
                    cv.Drzava = request.Drzava;
                }

                if (!String.IsNullOrEmpty(request.Grad))
                {
                    cv.Grad = request.Grad;
                }

                if (!String.IsNullOrEmpty(request.ProfesionalniSazetak))
                {
                    cv.ProfesionalniSazetak = request.ProfesionalniSazetak;
                }

                if (request.Vjestine != null)
                {
                    cv.Vjestine = request.Vjestine;
                }

                if (request.TehnickeVjestine != null)
                {
                    cv.TehnickeVjestine = request.TehnickeVjestine;
                }

                if (request.Kursevi != null)
                {
                    cv.Kursevi = request.Kursevi;
                }

                if (request.Edukacija != null)
                {

                    var brEdukacija = dbContext.CVEdukacija.Where(cvedukacija => cvedukacija.CVId == request.Id).Count();

                    if (request.Edukacija.Count() < brEdukacija)
                    {
                        var cvEdukacijaList = dbContext.CVEdukacija.Where(cvedukacija => cvedukacija.CVId == request.Id).ToList();

                        foreach (var cvedukacija in cvEdukacijaList)
                        {
                            var edukacijaExists = request.Edukacija.Where(x => x.Id == cvedukacija.EdukacijaId).FirstOrDefault();

                            if (edukacijaExists == null)
                            {
                                var edukacijaid = cvedukacija.EdukacijaId;

                                dbContext.Remove(cvedukacija);

                                await dbContext.SaveChangesAsync();

                                var edukacija = dbContext.Edukacija.Where(x => x.Id == edukacijaid).FirstOrDefault();

                                if(edukacija != null)  
                                    dbContext.Remove(edukacija);

                                await dbContext.SaveChangesAsync();

                            }
                        }
                    }

                    foreach (var edukacijaRequest in request.Edukacija)
                    {
                        var edukacijacv = cv.Edukacije.FirstOrDefault(edukacijacv => edukacijacv.Id == edukacijaRequest.Id);
                        if (edukacijacv != null)
                        {
                            var edukacija = dbContext.Edukacija.FirstOrDefault(edukacija => edukacija.Id == edukacijacv.EdukacijaId);

                            if (edukacija != null)
                            {
                                mapper.Map(edukacijaRequest, edukacija);
                            }
                        }
                    }

                    foreach (var edukacijaRequest in request.Edukacija)
                    {
                        var edukacijacv = cv.Edukacije.FirstOrDefault(edukacijacv => edukacijacv.EdukacijaId == edukacijaRequest.Id);

                        if (edukacijacv != null)
                        {
                            var edukacija = dbContext.Edukacija.FirstOrDefault(edukacija => edukacija.Id == edukacijacv.EdukacijaId);

                            if (edukacija != null)
                            {
                                mapper.Map(edukacijaRequest, edukacija);
                            }
                        }

                        else
                        {
                            var newEdukacija = new Edukacija();

                            mapper.Map(edukacijaRequest, newEdukacija);


                            dbContext.Edukacija.Add(newEdukacija);
                            await dbContext.SaveChangesAsync();  // Generisanje EdukacijaId


                            var cvEdukacija = new CVEdukacija
                            {
                                CVId = cv.Id,
                                EdukacijaId = newEdukacija.Id
                            };

                            dbContext.CVEdukacija.Add(cvEdukacija);

                        }
                    }
                }

                if (request.Zaposlenje != null)
                {

                    var brZaposlenja = dbContext.CVZaposlenje.Where(cvzaposlenje => cvzaposlenje.CVId == request.Id).Count();

                    if (request.Zaposlenje.Count() < brZaposlenja)
                    {
                        var cvZaposlenjeList = dbContext.CVZaposlenje.Where(cvzaposlenje => cvzaposlenje.CVId == request.Id).ToList();

                        foreach (var cvzaposlenje in cvZaposlenjeList)
                        {
                            var zaposlenjeExists = request.Zaposlenje.Where(x => x.Id == cvzaposlenje.ZaposlenjeId).FirstOrDefault();

                            if (zaposlenjeExists == null)
                            {
                                var zaposlenjeid = cvzaposlenje.ZaposlenjeId;

                                dbContext.Remove(cvzaposlenje);

                                await dbContext.SaveChangesAsync();

                                var zaposlenje = dbContext.Zaposlenje.Where(x => x.Id == zaposlenjeid).FirstOrDefault();

                                if (zaposlenje != null) 
                                    dbContext.Remove(zaposlenje);

                                await dbContext.SaveChangesAsync();

                            }
                        }
                    }

                    foreach (var zaposlenjeRequest in request.Zaposlenje)
                    {
                        var zaposlenjecv = cv.Zaposlenja.FirstOrDefault(zaposlenjecv => zaposlenjecv.ZaposlenjeId == zaposlenjeRequest.Id);

                        if (zaposlenjecv != null)
                        {
                            var zaposlenje = dbContext.Zaposlenje.FirstOrDefault(zaposlenje => zaposlenje.Id == zaposlenjecv.ZaposlenjeId);

                            if (zaposlenje != null)
                            {
                                mapper.Map(zaposlenjeRequest, zaposlenje);
                            }
                        }

                        else
                        {

                            var newZaposlenje = new Zaposlenje();

                            mapper.Map(zaposlenjeRequest, newZaposlenje);

                            dbContext.Zaposlenje.Add(newZaposlenje);
                            await dbContext.SaveChangesAsync();  // Generisanje ZaposlenjeId

                            // Dodavanje CVURL

                            var cvZaposlenje = new CVZaposlenje
                            {
                                CVId = cv.Id,
                                ZaposlenjeId = newZaposlenje.Id
                            };

                            dbContext.CVZaposlenje.Add(cvZaposlenje);
                        }
                    }
                }


                if (request.URL != null)
                {

                    var brUrl = dbContext.CVURL.Where(cvurl => cvurl.CVId == request.Id).Count();

                    if (request.URL.Count() < brUrl)
                    {
                        var cvURlList = dbContext.CVURL.Where(cvurl => cvurl.CVId == request.Id).ToList();

                        foreach (var cvurl in cvURlList)
                        {
                            var urlExists = request.URL.Where(x => x.Id == cvurl.URLId).FirstOrDefault();

                            if (urlExists == null)
                            {
                                var urlid = cvurl.URLId;

                                dbContext.Remove(cvurl);

                                await dbContext.SaveChangesAsync();

                                var url = dbContext.URL.Where(x => x.Id == urlid).FirstOrDefault();

                                if (url != null) 
                                    dbContext.Remove(url);

                                await dbContext.SaveChangesAsync();


                            }
                        }
                    }

                    foreach (var urlRequest in request.URL)
                    {
                        var urlcv = cv.URLovi.FirstOrDefault(urlcv => urlcv.URLId == urlRequest.Id);

                        if (urlcv != null)
                        {
                            var url = dbContext.URL.FirstOrDefault(url => url.Id == urlcv.URLId);

                            if (url != null)
                            {
                                mapper.Map(urlRequest, url);
                            }
                        }

                        else
                        {

                            var newUrl = new URL();

                            mapper.Map(urlRequest, newUrl);

                            dbContext.URL.Add(newUrl);
                            await dbContext.SaveChangesAsync();  // Generisanje URLId

                            // Dodavanje CVURL

                            var cvURL = new CVURL
                            {
                                CVId = cv.Id,
                                URLId = newUrl.Id
                            };

                            dbContext.CVURL.Add(cvURL);
                        }
                    }
                }

                cv.DatumModificiranja = DateTime.Now; 

                await dbContext.SaveChangesAsync();

                return new CVUpdateResponse { Id = cv.Id };
            }

            else return Unauthorized();
        }
    }
}
