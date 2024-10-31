using JobSearchingWebApp.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.CV.GetAll
{
    public class CVGetAllResponse
    {
        public List<CVGetAllResponseCV> CV { get; set; }
    }

    public class CVGetAllResponseCV
    {
        public int Id { get; set; }

        public bool Objavljen { get; set; }

        public string Naziv { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public string Zvanje { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Drzava { get; set; }

        public string? Grad { get; set; }

        public string? ProfesionalniSazetak { get; set; }

        public DateTime DatumModificiranja { get; set; }

    }
}
