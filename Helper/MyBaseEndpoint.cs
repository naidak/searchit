using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JobSearchingWebApp.Helper
{
    [ApiController]
    [Route("[controller]")]
    public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
    {
        public abstract Task<TResponse> MyAction (TRequest request, CancellationToken cancellationToken);    
    }
}
