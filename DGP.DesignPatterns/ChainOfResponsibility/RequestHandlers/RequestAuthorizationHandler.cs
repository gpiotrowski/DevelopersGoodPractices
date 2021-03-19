using DGP.DesignPatterns.ChainOfResponsibility.Models;

namespace DGP.DesignPatterns.ChainOfResponsibility.RequestHandlers
{
    public class RequestAuthorizationHandler : RequestHandlerBase
    {
        public override void ProcessRequest(Request request)
        {
            if (request.UserId < 100)
            {
                request.RequestOutput = "Unauthorized!";
            }
            else
            {
                Next(request);
            }
        }
    }
}