using JobSearchingWebApp.Endpoints.CV.Dodaj;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace JobSearchingWebApp.Endpoints.CV.Update
{
    public class CVUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string KandidatId { get; set; }

        public string? Naziv { get; set; }

        public bool? Objavljen { get; set; }

        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public string? Email { get; set; }

        public string? Drzava { get; set; }

        public string? Grad { get; set; }

        public string? ProfesionalniSazetak { get; set; }

        public List<string>? Vjestine { get; set; }

        public List<string>? TehnickeVjestine { get; set; }

        public List<string>? Kursevi { get; set; }

        public List<EdukacijaUpdateRequest>? Edukacija { get; set; }

        public List<ZaposlenjeUpdateRequest>? Zaposlenje { get; set; }

        public List<URLUpdateRequest>? URL { get; set; }
    }

    public class EdukacijaUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        public string? NazivSkole { get; set; }

        public DateOnly? DatumPocetka { get; set; }

        public DateOnly? DatumZavrsetka { get; set; }

        public string? Grad { get; set; }

        public string? Opis { get; set; }
    }

    public class ZaposlenjeUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        public string? NazivKompanije { get; set; }

        public string? NazivPozicije { get; set; }

        public DateOnly? DatumPocetka { get; set; }

        public DateOnly? DatumZavrsetka { get; set; }

        public string? Opis { get; set; }
    }

    public class URLUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        public string? Naziv { get; set; }

        [Url]
        public string? Putanja { get; set; }
    }
}
