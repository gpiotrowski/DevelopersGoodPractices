using DGP.DesignPatterns.AbstractFactory.Computers;
using DGP.DesignPatterns.AbstractFactory.Monitors;

namespace DGP.DesignPatterns.AbstractFactory
{
    public interface IDeskDevicesAbstractFactory
    {
        IMonitor CreateMonitor();
        IComputer CreateComputer();
    }
}
