using DGP.DesignPatterns.ChainOfResponsibility.Models;

namespace DGP.DesignPatterns.ChainOfResponsibility.RequestHandlers
{
    public class RequestHandler : RequestHandlerBase
    {
        public override void ProcessRequest(Request request)
        {
            request.RequestOutput = "Done!";
            Next(request);
        }
    }
}
