using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KompanijaKandidat.GetAll
{
    public class KompanijaKandidatGetAllRequest
    {
        public string? kompanija_id { get; set; }

        public string? kandidat_id { get; set; }

        public DateTime? datum_razgovora { get; set; }
    }
}
