namespace JobSearchingWebApp.Endpoints.Poruka.GetByKorisnikId
{
    public class PorukaGetResponse
    {
        public List<PorukaGetResponsePoruka> Poruke { get; set; }
    }

    public class PorukaGetResponsePoruka
    {
        public int id { get; set; }
        public string korisnik_id { get; set; }
        public int poruka_id { get; set; }
        public bool is_primljena { get; set; }
        public string posiljatelj_id { get; set; }
        public string ime_posiljatelja { get; set; }
        public DateTime vrijeme_slanja { get; set; }
        public bool is_seen { get; set; }
        public string  sadrzaj { get; set; }
    }
}
