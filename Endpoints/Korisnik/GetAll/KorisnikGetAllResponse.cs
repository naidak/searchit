namespace JobSearchingWebApp.Endpoints.Korisnik.GetAll
{
    public class KorisnikGetAllResponse
    {
        public List<KorisnikGetAllResponseKorisnik> Korisnici { get; set; }
    }

    public class KorisnikGetAllResponseKorisnik
    {
        public string Uloga { get; set; }

        public bool IsObrisan { get; set; } = false;
    }
}
