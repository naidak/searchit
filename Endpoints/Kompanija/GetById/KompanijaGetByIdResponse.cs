using JobSearchingWebApp.Database;

namespace JobSearchingWebApp.Endpoints.Kompanija.GetById
{
    public class KompanijaGetByIdResponse : Database.Korisnik
    {
        public string Naziv { get; set; }

        public int GodinaOsnivanja { get; set; }

        public string Lokacija { get; set; }

        public string BrojZaposlenih { get; set; }

        public string KratkiOpis { get; set; }

        public string? Logo { get; set; }

        public string Opis { get; set; }

        public string? Website { get; set; }

        public string? LinkedIn { get; set; }

        public string? Twitter { get; set; }

        public int BrojOtvorenihPozicija { get; set; }
    }
}
