using JobSearchingWebApp.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.CV.GetById
{
    public class CVGetByIdResponse
    {
        public int Id { get; set; }

        public string KandidatId { get; set; }

        public bool Objavljen { get; set; }

        public string Naziv { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Drzava { get; set; }

        public string? Grad { get; set; }

        public string? ProfesionalniSazetak { get; set; }

        public DateTime DatumModificiranja { get; set; }

        public List<string>? Vjestine { get; set; }

        public List<string>? TehnickeVjestine { get; set; }

        public List<string>? Kursevi { get; set; }

        public List<EdukacijaResponse>? Edukacija { get; set; }

        public List<ZaposlenjeResponse>? Zaposlenje { get; set; }

        public List<URLResponse>? URL { get; set; }
    }

    public class EdukacijaResponse
    {
        public int Id { get; set; }

        public string NazivSkole { get; set; }

        public DateOnly? DatumPocetka { get; set; }

        public DateOnly? DatumZavrsetka { get; set; }

        public string? Grad { get; set; }

        public string? Opis { get; set; }
    }

    public class ZaposlenjeResponse
    {
        public int Id { get; set; }

        public string NazivKompanije { get; set; }

        public string NazivPozicije { get; set; }

        public DateOnly DatumPocetka { get; set; }

        public DateOnly? DatumZavrsetka { get; set; }

        public string? Opis { get; set; }
    }

    public class URLResponse
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Putanja { get; set; }
    }
}
