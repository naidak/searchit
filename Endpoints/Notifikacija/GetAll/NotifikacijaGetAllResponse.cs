namespace JobSearchingWebApp.Endpoints.Notifikacija.GetAll
{
    public class NotifikacijaGetAllResponse
    {
        public List<NotifikacijeGetAllResponse> Notifikacije { get; set; }
    }

    public class NotifikacijeGetAllResponse
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Vrsta { get; set; }
    }
}
