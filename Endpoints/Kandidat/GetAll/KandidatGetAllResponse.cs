namespace JobSearchingWebApp.Endpoints.Kandidat.GetAll
{
    public class KandidatGetAllResponse
    {
        public List<KandidatiGetAllResponse> Kandidati { get; set; }
    }

    public class KandidatiGetAllResponse
    {
        public string Id { get; set; } 

        public string Email { get; set; }

        public string Username { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string MjestoPrebivalista { get; set; }

        public string Zvanje { get; set; }

        public string PhoneNumber { get; set; }
    }
}
