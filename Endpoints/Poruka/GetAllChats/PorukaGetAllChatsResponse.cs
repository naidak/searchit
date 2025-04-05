namespace JobSearchingWebApp.Endpoints.Poruka.GetAllChats
{
    public class PorukaGetAllChatsResponse
    {    
        public List<PorukaGetAllChatsResponsePoruka> poruke { get; set; }
        public int broj_neprocitanih { get; set; }
        public int total_poruka { get; set; }
    }

    public class PorukaGetAllChatsResponsePoruka
    {
        public int id { get; set; }
        public string primatelj_id { get; set; }
        public string primatelj_ime { get; set; }
        public string posiljatelj_id { get; set; }
        public string posiljatelj_ime { get; set; }
        public string sadrzaj { get; set; }
        public DateTime vrijeme_slanja { get; set; }
        public bool is_seen { get; set; }
    }
}
