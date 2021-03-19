using DGP.DesignPatterns.AbstractFactory.Computers;
using DGP.DesignPatterns.AbstractFactory.Monitors;

namespace DGP.DesignPatterns.AbstractFactory
{
    public class StandardDeskDevicesFactory : IDeskDevicesAbstractFactory
    {
        public IMonitor CreateMonitor()
        {
            return new StandardMonitor();
        }

        public IComputer CreateComputer()
        {
            return new AverageLaptop();
        }
    }
}