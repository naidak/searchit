using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Kompanija.GetById
{
    public class KompanijaGetByIdRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
