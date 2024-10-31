using JobSearchingWebApp.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace JobSearchingWebApp.Endpoints.Kompanija.GetAll
{
    public class KompanijaGetAllRequest
    {
        public string? Naziv { get; set; }

        public List<string>? Lokacija { get; set; }

        public List<string>? BrojZaposlenih { get; set; }

        public string? ImaOtvorenePozicije { get; set; }

        public bool? Spasen { get; set; }

        public string? KandidatId { get; set; }

        public List<SortParametar>? SortParametri { get; set; }
    }
}
