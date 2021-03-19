using DGP.DesignPatterns.ChainOfResponsibility.Models;

namespace DGP.DesignPatterns.ChainOfResponsibility.RequestHandlers
{
    public abstract class RequestHandlerBase
    {
        private RequestHandlerBase _nextHandler;

        public abstract void ProcessRequest(Request request);

        protected void Next(Request request)
        {
            _nextHandler?.ProcessRequest(request);
        }

        public void SetNext(RequestHandlerBase nextRequestHandler)
        {
            _nextHandler = nextRequestHandler;
        }
    }
}