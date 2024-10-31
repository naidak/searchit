using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.Oglas.GetById
{
    public class OglasGetByIdResponse
    {
        public int Id { get; set; }

        public string KompanijaNaziv { get; set; }

        public string? Logo { get; set; }

        public string KompanijaId { get; set; }

        public string NazivPozicije { get; set; }

        public DateTime DatumObjave { get; set; }

        public string Plata { get; set; }

        public string TipPosla { get; set; }

        public DateTime RokPrijave { get; set; }

        public DateTime? DatumModificiranja { get; set; }

        public List<OglasGetByIdResponseOglasLokacija> Lokacija { get; set; }

        public List<OglasGetByIdResponseOglasIskustvo> Iskustvo {  get; set; }

        public OglasGetByIdResponseOpisOglasa? OpisOglasa { get; set; }
    }

    public class OglasGetByIdResponseOpisOglasa
    {
        public string OpisPozicije { get; set; }

        public int? MinimumGodinaIskustva { get; set; }

        public int? PrefiraneGodineIskstva { get; set; }

        public string? Kvalifikacija { get; set; }

        public string? Vjestine { get; set; }

        public string? Benefiti { get; set; }
    }

    public class OglasGetByIdResponseOglasLokacija
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }

    public class OglasGetByIdResponseOglasIskustvo
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }
}
