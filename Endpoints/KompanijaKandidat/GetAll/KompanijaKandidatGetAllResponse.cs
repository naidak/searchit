using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KompanijaKandidat.GetAll
{
    public class KompanijaKandidatGetAllResponse
    {
        public List<KompanijeKandidatiGetAllResponse> KompanijeKandidati {  get; set; }    
    }

    public class KompanijeKandidatiGetAllResponse
    {
        public string KompanijaId { get; set; }

        public string KandidatId { get; set; }

        public DateTime DatumRazgovora { get; set; }
    }
}
