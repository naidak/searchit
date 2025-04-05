using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchingWebApp.Endpoints.Poruka.MarkAsRead
{
    [Route("/mark-as-read")]
    [ApiController]
    public class PorukaMarkAsReadEndpoint : MyBaseEndpoint<PorukaMarkAsReadRequest, PorukaMarkAsReadResponse>
    {
        private readonly ApplicationDbContext dbContext;
        public PorukaMarkAsReadEndpoint(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        [HttpPut]
        public override async Task<PorukaMarkAsReadResponse> MyAction(PorukaMarkAsReadRequest request, CancellationToken cancellationToken)
        {
            var poruka = dbContext.Poruke.FirstOrDefault(x => x.Id == request.poruka_id);

            if (poruka != null)
            {
                poruka.IsSeen = true;
                await dbContext.SaveChangesAsync(cancellationToken);
                return new PorukaMarkAsReadResponse { success = true, message = "Message marked as read." };
            }

            return new PorukaMarkAsReadResponse { success = false, message = "Message not found." };
        }

    }
}
