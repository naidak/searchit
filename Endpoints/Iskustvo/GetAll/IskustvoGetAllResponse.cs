using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Iskustvo.GetAll
{
    public class IskustvoGetAllResponse
    {
        public List<IskustvoGetAllResponseIskustvo> Iskustva { get; set; }
    }

    public class IskustvoGetAllResponseIskustvo
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }
}
