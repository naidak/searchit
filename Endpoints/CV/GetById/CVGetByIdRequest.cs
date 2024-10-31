using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.CV.GetById
{
    public class CVGetByIdRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
