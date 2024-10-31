namespace JobSearchingWebApp.Endpoints.KandidatOglas.GetAll
{
    public class KandidatOglasGetAllRequest
    {
        public string? KandidatId { get; set; }

        public string? KompanijaId { get; set; }

        public string? PretragaNaziv { get; set; }

        public bool? Spasen { get; set; }

        public string? Status { get; set; }

        public bool? Otvoren { get; set; }

    }
}
