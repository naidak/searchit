using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Oglas.Delete
{
    public class OglasDeleteRequest
    {
        [Required]
        public int oglas_id { get; set; }   
    }
}
