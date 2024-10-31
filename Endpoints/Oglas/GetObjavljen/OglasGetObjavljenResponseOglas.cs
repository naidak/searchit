using JobSearchingWebApp.Endpoints.Oglas.GetById;

namespace JobSearchingWebApp.Endpoints.Oglas.Dodaj.GetObjavljen
{
    public class OglasGetObjavljenResponse
    {
        public List<OglasGetObjavljenResponseOglas> Oglasi { get; set; }
    }
    public class OglasGetObjavljenResponseOglas
    {
        public int Id { get; set; }

        public string KompanijaNaziv { get; set; }

        public string KompanijaId { get; set; }

        public string NazivPozicije { get; set; }

        public DateTime DatumObjave { get; set; }

        public string Plata { get; set; }

        public string TipPosla { get; set; }

        public DateTime RokPrijave { get; set; }

        public DateTime? DatumModificiranja { get; set; }

        public List<OglasGetByObjavljenResponseOglasLokacija> Lokacija { get; set; }

        public List<OglasGetByObjavljenResponseOglasIskustvo> Iskustvo { get; set; }

        public OglasGetByObjavljenResponseOpisOglasa? OpisOglasa { get; set; }
    }

    public class OglasGetByObjavljenResponseOpisOglasa
    {
        public string OpisPozicije { get; set; }

        public int MinimumGodinaIskustva { get; set; }

        public int PrefiraneGodineIskstva { get; set; }

        public string? Kvalifikacija { get; set; }

        public string? Vjestine { get; set; }

        public string? Benefiti { get; set; }
    }

    public class OglasGetByObjavljenResponseOglasLokacija
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }

    public class OglasGetByObjavljenResponseOglasIskustvo
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }
}
