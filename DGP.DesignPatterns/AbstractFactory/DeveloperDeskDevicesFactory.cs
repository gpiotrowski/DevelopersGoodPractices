using DGP.DesignPatterns.AbstractFactory.Computers;
using DGP.DesignPatterns.AbstractFactory.Monitors;

namespace DGP.DesignPatterns.AbstractFactory
{
    public class DeveloperDeskDevicesFactory : IDeskDevicesAbstractFactory
    {
        public IMonitor CreateMonitor()
        {
            return new WideScreenMonitor();
        }

        public IComputer CreateComputer()
        {
            return new BestSpecLaptop();
        }
    }
}