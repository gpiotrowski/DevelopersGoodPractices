using System;
using DGP.DesignPatterns.ChainOfResponsibility.Models;

namespace DGP.DesignPatterns.ChainOfResponsibility.RequestHandlers
{
    public class RequestInputLogger : RequestHandlerBase
    {
        public override void ProcessRequest(Request request)
        {
            Console.WriteLine(request.RequestInput);
            Next(request);
        }
    }
}