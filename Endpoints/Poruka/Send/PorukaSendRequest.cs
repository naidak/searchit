namespace JobSearchingWebApp.Endpoints.Poruka.Send
{
    public class PorukaSendRequest
    {
        public string korisnik_id { get; set; }
        public string posiljatelj_id { get; set; }
        public string sadrzaj { get; set; }
    }
}
