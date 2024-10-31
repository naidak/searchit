namespace JobSearchingWebApp.Endpoints.Oglas.Update
{
    public class OglasUpdateRequest
    {
        public int oglas_id { get; set; }

        public string? naziv_pozicije { get; set; }

        public DateTime? rok_prijave { get; set; }

        public string? plata { get; set; }

        public string? tip_posla { get; set; }

        public DateTime datum_modificiranja { get; set; }

        public OglasUpdateOpisOglasa opis_oglasa { get; set; }

        public ICollection<OglasUpdateOglasLokacija> lokacija { get; set; }

        public ICollection<OglasUpdateOglasIskustvo> iskustvo { get; set; }


    }

    public class OglasUpdateOpisOglasa
    {

        public string opis_pozicije { get; set; }

        public int? minimum_godina_iskustva { get; set; }

        public int? preferirane_godine_iskustva { get; set; }

        public string? benefiti { get; set; }

        public string? vjestine { get; set; }

        public string? kvalifikacije { get; set; }
    }

    public class OglasUpdateOglasIskustvo
    {
        public int id { get; set; }

        public string? naziv { get; set; }
    }

    public class OglasUpdateOglasLokacija
    {
        public int id { get; set; }

        public string? naziv { get; set; }
    }

}
