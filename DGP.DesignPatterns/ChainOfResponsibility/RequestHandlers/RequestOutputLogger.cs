using System;
using DGP.DesignPatterns.ChainOfResponsibility.Models;

namespace DGP.DesignPatterns.ChainOfResponsibility.RequestHandlers
{
    public class RequestOutputLogger : RequestHandlerBase
    {
        public override void ProcessRequest(Request request)
        {
            Console.WriteLine(request.RequestOutput);
            Next(request);
        }
    }
}