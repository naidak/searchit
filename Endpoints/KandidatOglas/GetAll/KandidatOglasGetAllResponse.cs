using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace JobSearchingWebApp.Endpoints.KandidatOglas.GetAll
{
    public class KandidatOglasGetAllResponse
    {
        public List<KandidatOglasGetAllResponseKandidatOglas> KandidatOglasi { get; set; }
    }

    public class KandidatOglasGetAllResponseKandidatOglas
    {
        public int Id { get; set; }

        public string KandidatId { get; set; }

        public string Ime  { get; set; }

        public string Prezime { get; set; }

        public string Zvanje { get; set; }

        public int OglasId { get; set; }

        public string NazivPozicije { get; set; }

        public string NazivKompanije { get; set; }

        public DateTime RokPrijave { get; set; }

        public bool Otvoren { get; set; }

        public int CVId { get; set; }

        public string CVNaziv { get; set; }

        public DateTime DatumPrijave { get; set; }

        public string Status { get; set; }

        public bool Spasen { get; set; }
    }
}
