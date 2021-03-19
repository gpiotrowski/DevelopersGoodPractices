using DGP.DesignPatterns.ChainOfResponsibility.Models;
using DGP.DesignPatterns.ChainOfResponsibility.RequestHandlers;

namespace DGP.DesignPatterns.ChainOfResponsibility
{
    class Client
    {
        public void Execute()
        {
            var requestInputLogger = new RequestInputLogger();
            var requestAuthorizationHandler = new RequestAuthorizationHandler();
            var requestHandler = new RequestHandler();
            var requestOutputLogger = new RequestOutputLogger();

            requestInputLogger.SetNext(requestAuthorizationHandler);
            requestAuthorizationHandler.SetNext(requestHandler);
            requestHandler.SetNext(requestOutputLogger);

            var request = new Request();

            requestInputLogger.ProcessRequest(request);
        }
    }
}
