using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JobSearchingWebApp.Database;

namespace JobSearchingWebApp.Endpoints.Oglas.GetAll
{
    public class OglasGetAllResponse
    {
        public List<OglasGetAllResponseOglas> Oglasi {  get; set; } 
    }

    public class OglasGetAllResponseOglas
    {
        public int Id { get; set; }

        public string KompanijaNaziv { get; set; }

        public string? Logo { get; set; }

        public string NazivPozicije { get; set; }

        public List<OglasGetAllResponseOglasLokacija> Lokacija { get; set; }

        public DateTime DatumObjave { get; set; }

        public string TipPosla { get; set; }

        public DateTime RokPrijave { get; set; }

        public List<OglasGetAllResponseOglasIskustvo> Iskustvo { get; set; }

        public OglasGetAllResponseOpisOglas OpisOglasa { get; set; }

        public int RazlikaDana => (DateTime.Today - RokPrijave).Days;

        public bool Spasen { get; set; }

        public bool? Objavljen { get; set; }

        public bool IsObrisan { get; set; }
    }

    public class OglasGetAllResponseOglasLokacija
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }

    public class OglasGetAllResponseOglasIskustvo
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }

    public class OglasGetAllResponseOpisOglas
    {
        public int Id { get; set; }

        public int MinimumGodinaIskustva { get; set; }

        public int PrefiraneGodineIskstva { get; set; }
    }
}
