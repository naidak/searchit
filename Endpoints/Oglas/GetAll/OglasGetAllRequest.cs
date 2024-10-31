using System.Reflection.Metadata.Ecma335;
using JobSearchingWebApp.ViewModels;

namespace JobSearchingWebApp.Endpoints.Oglas.GetAll
{
    public class OglasGetAllRequest
    {
        public string? Naziv { get; set; }

        public List<string>? Lokacija { get; set; }

        public List<string>? TipPosla { get; set; }

        public List<string>? Iskustvo { get; set; }

        public int? MinimumGodinaIskustva { get; set; }

        public bool? Spasen { get; set; }

        public string? KandidatId { get; set; }

        public string? KompanijaId { get; set; }

        public bool? Otvoren { get; set; }

        public bool? Objavljen { get; set; }

        public List<SortParametar>? SortParametri { get; set; }
    }
}
