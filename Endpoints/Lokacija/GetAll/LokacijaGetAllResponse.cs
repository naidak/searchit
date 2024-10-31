using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Lokacija.GetAll
{
    public class LokacijaGetAllResponse
    {
        public List<LokacijaGetAllResponseLokacija> Lokacije { get; set; }
    }

    public class LokacijaGetAllResponseLokacija
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }
}
