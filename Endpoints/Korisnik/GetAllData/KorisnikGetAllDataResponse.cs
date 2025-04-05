namespace JobSearchingWebApp.Endpoints.Korisnik.GetAllData
{
    public class KorisnikGetAllDataResponse
    {
        public List<KorisnikGetAllDataResponseKorisnik> Korisnici { get; set; }
    }

    public class KorisnikGetAllDataResponseKorisnik
    {
        public string Username { get; set; }
        public string Uloga { get; set; }

        public bool IsObrisan { get; set; } = false;
    }
}
